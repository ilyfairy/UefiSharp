namespace System;

public struct DateTime
{
    // Number of 100ns ticks per time unit
    internal const int MicrosecondsPerMillisecond = 1000;
    private const long TicksPerMicrosecond = 10;
    private const long TicksPerMillisecond = TicksPerMicrosecond * MicrosecondsPerMillisecond;

    private const int HoursPerDay = 24;
    private const long TicksPerSecond = TicksPerMillisecond * 1000;
    private const long TicksPerMinute = TicksPerSecond * 60;
    private const long TicksPerHour = TicksPerMinute * 60;
    private const long TicksPerDay = TicksPerHour * HoursPerDay;

    // Number of milliseconds per time unit
    private const int MillisPerSecond = 1000;
    private const int MillisPerMinute = MillisPerSecond * 60;
    private const int MillisPerHour = MillisPerMinute * 60;
    private const int MillisPerDay = MillisPerHour * HoursPerDay;

    // Number of days in a non-leap year
    private const int DaysPerYear = 365;
    // Number of days in 4 years
    private const int DaysPer4Years = DaysPerYear * 4 + 1;       // 1461
                                                                 // Number of days in 100 years
    private const int DaysPer100Years = DaysPer4Years * 25 - 1;  // 36524
                                                                 // Number of days in 400 years
    private const int DaysPer400Years = DaysPer100Years * 4 + 1; // 146097

    // Number of days from 1/1/0001 to 12/31/1600
    private const int DaysTo1601 = DaysPer400Years * 4;          // 584388
                                                                 // Number of days from 1/1/0001 to 12/30/1899
    private const int DaysTo1899 = DaysPer400Years * 4 + DaysPer100Years * 3 - 367;
    // Number of days from 1/1/0001 to 12/31/1969
    internal const int DaysTo1970 = DaysPer400Years * 4 + DaysPer100Years * 3 + DaysPer4Years * 17 + DaysPerYear; // 719,162
                                                                                                                  // Number of days from 1/1/0001 to 12/31/9999
    private const int DaysTo10000 = DaysPer400Years * 25 - 366;  // 3652059

    internal const long MinTicks = 0;
    internal const long MaxTicks = DaysTo10000 * TicksPerDay - 1;
    private const long MaxMicroseconds = MaxTicks / TicksPerMicrosecond;
    private const long MaxMillis = MaxTicks / TicksPerMillisecond;
    private const long MaxSeconds = MaxTicks / TicksPerSecond;
    private const long MaxMinutes = MaxTicks / TicksPerMinute;
    private const long MaxHours = MaxTicks / TicksPerHour;
    private const long MaxDays = (long)DaysTo10000 - 1;

    internal const long UnixEpochTicks = DaysTo1970 * TicksPerDay;
    private const long FileTimeOffset = DaysTo1601 * TicksPerDay;
    private const long DoubleDateOffset = DaysTo1899 * TicksPerDay;
    // The minimum OA date is 0100/01/01 (Note it's year 100).
    // The maximum OA date is 9999/12/31
    private const long OADateMinAsTicks = (DaysPer100Years - DaysPerYear) * TicksPerDay;
    // All OA dates must be greater than (not >=) OADateMinAsDouble
    private const double OADateMinAsDouble = -657435.0;
    // All OA dates must be less than (not <=) OADateMaxAsDouble
    private const double OADateMaxAsDouble = 2958466.0;

    // Euclidean Affine Functions Algorithm (EAF) constants

    // Constants used for fast calculation of following subexpressions
    //      x / DaysPer4Years
    //      x % DaysPer4Years / 4
    private const uint EafMultiplier = (uint)(((1UL << 32) + DaysPer4Years - 1) / DaysPer4Years);   // 2,939,745
    private const uint EafDivider = EafMultiplier * 4;                                              // 11,758,980

    private const ulong TicksPer6Hours = TicksPerHour * 6;
    private const int March1BasedDayOfNewYear = 306;              // Days between March 1 and January 1

    internal static ReadOnlySpan<uint> DaysToMonth365 => [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365];
    internal static ReadOnlySpan<uint> DaysToMonth366 => [0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366];

    private static ReadOnlySpan<byte> DaysInMonth365 => [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    private static ReadOnlySpan<byte> DaysInMonth366 => [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    public static readonly DateTime MinValue;
    public static readonly DateTime MaxValue = new DateTime(MaxTicks, DateTimeKind.Unspecified);
    public static readonly DateTime UnixEpoch = new DateTime(UnixEpochTicks, DateTimeKind.Utc);

    private const ulong TicksMask = 0x3FFFFFFFFFFFFFFF;
    private const ulong FlagsMask = 0xC000000000000000;
    private const long TicksCeiling = 0x4000000000000000;
    private const ulong KindUnspecified = 0x0000000000000000;
    private const ulong KindUtc = 0x4000000000000000;
    private const ulong KindLocal = 0x8000000000000000;
    private const ulong KindLocalAmbiguousDst = 0xC000000000000000;
    private const int KindShift = 62;

    private const string TicksField = "ticks"; // Do not rename (binary serialization)
    private const string DateDataField = "dateData"; // Do not rename (binary serialization)

    // The data is stored as an unsigned 64-bit integer
    //   Bits 01-62: The value of 100-nanosecond ticks where 0 represents 1/1/0001 12:00am, up until the value
    //               12/31/9999 23:59:59.9999999
    //   Bits 63-64: A four-state value that describes the DateTimeKind value of the date time, with a 2nd
    //               value for the rare case where the date time is local, but is in an overlapped daylight
    //               savings time hour and it is in daylight savings time. This allows distinction of these
    //               otherwise ambiguous local times and prevents data loss when round tripping from Local to
    //               UTC time.
    private readonly ulong _dateData;

    //internal static DateTime UnsafeCreate(long ticks) => new DateTime((ulong)ticks);

    public DateTime(long ticks)
    {
        //if ((ulong)ticks > MaxTicks) ThrowTicksOutOfRange();
        _dateData = (ulong)ticks;
    }


    public DateTime(long ticks, DateTimeKind kind)
    {
        //if ((ulong)ticks > MaxTicks) ThrowTicksOutOfRange();
        //if ((uint)kind > (uint)DateTimeKind.Local) ThrowInvalidKind();
        _dateData = (ulong)ticks | ((ulong)(uint)kind << KindShift);
    }
}

public enum DateTimeKind
{
    Unspecified = 0,
    Utc = 1,
    Local = 2,
}