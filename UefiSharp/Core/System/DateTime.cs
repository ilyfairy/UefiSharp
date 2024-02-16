using EFI.RuntimeServices;
using EFI.Times;

namespace System;

public struct DateTime
{
    private static unsafe EFI_RUNTIME_SERVICES* runtimeServices;

    public static unsafe void Initialize(EFI_RUNTIME_SERVICES* efiRuntimeServices) => runtimeServices = efiRuntimeServices;



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


    private static readonly (uint, uint, uint, uint, uint, uint, uint, uint, uint, uint, uint, uint, uint) _DaysToMonth365 = (0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365);
    private static readonly (uint, uint, uint, uint, uint, uint, uint, uint, uint, uint, uint, uint, uint) _DaysToMonth366 = (0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366);
    internal static ReadOnlySpan<uint> DaysToMonth365 => new ReadOnlySpan<uint>(in _DaysToMonth365.Item1, 13);
    internal static ReadOnlySpan<uint> DaysToMonth366 => new ReadOnlySpan<uint>(in _DaysToMonth366.Item1, 13);


    private static (byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte) _DaysInMonth365 = (31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
    private static (byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte) _DaysInMonth366 = (31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
    private static ReadOnlySpan<byte> DaysInMonth365 => new ReadOnlySpan<byte>(in _DaysInMonth365.Item1, 12);
    private static ReadOnlySpan<byte> DaysInMonth366 => new ReadOnlySpan<byte>(in _DaysInMonth366.Item1, 12);


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

    private static bool SystemSupportsLeapSeconds => true;

    private ulong UTicks => _dateData & TicksMask;

    public static unsafe DateTime Now
    {
        get
        {
            EFI_TIME time;
            EFI_TIME_CAPABILITIES capabilities;
            var result = runtimeServices->GetTime.Invoke(&time, &capabilities);

            if (!result.IsSuccess)
                return default;

            return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, (int)(time.Nanosecond / 1_000_000), DateTimeKind.Utc);
        }
    }

    public int Year
    {
        get
        {
            // y100 = number of whole 100-year periods since 1/1/0001
            // r1 = (day number within 100-year period) * 4
            (uint y100, uint r1) = Math.DivRem(((uint)(UTicks / TicksPer6Hours) | 3U), DaysPer400Years);
            return 1 + (int)(100 * y100 + (r1 | 3) / DaysPer4Years);
        }
    }

    public int Day
    {
        get
        {
            // r1 = (day number within 100-year period) * 4
            uint r1 = (((uint)(UTicks / TicksPer6Hours) | 3U) + 1224) % DaysPer400Years;
            ulong u2 = (ulong)Math.BigMul((int)EafMultiplier, (int)r1 | 3);
            ushort daySinceMarch1 = (ushort)((uint)u2 / EafDivider);
            int n3 = 2141 * daySinceMarch1 + 197913;
            // Return 1-based day-of-month
            return (ushort)n3 / 2141 + 1;
        }
    }

    public int Hour => (int)((uint)(UTicks / TicksPerHour) % 24);

    public int DayOfYear => 1 + (int)(((((uint)(UTicks / TicksPer6Hours) | 3U) % (uint)DaysPer400Years) | 3U) * EafMultiplier / EafDivider);

    public int Month
    {
        get
        {
            // r1 = (day number within 100-year period) * 4
            uint r1 = (((uint)(UTicks / TicksPer6Hours) | 3U) + 1224) % DaysPer400Years;
            ulong u2 = (ulong)Math.BigMul((int)EafMultiplier, (int)r1 | 3);
            ushort daySinceMarch1 = (ushort)((uint)u2 / EafDivider);
            int n3 = 2141 * daySinceMarch1 + 197913;
            return (ushort)(n3 >> 16) - (daySinceMarch1 >= March1BasedDayOfNewYear ? 12 : 0);
        }
    }

    // Returns the millisecond part of this DateTime. The returned value
    // is an integer between 0 and 999.
    //
    public int Millisecond => (int)((UTicks / TicksPerMillisecond) % 1000);

    /// <summary>
    /// The microseconds component, expressed as a value between 0 and 999.
    /// </summary>
    public int Microsecond => (int)((UTicks / TicksPerMicrosecond) % 1000);

    /// <summary>
    /// The nanoseconds component, expressed as a value between 0 and 900 (in increments of 100 nanoseconds).
    /// </summary>
    public int Nanosecond => (int)(UTicks % TicksPerMicrosecond) * 100;

    /// <summary>
    /// Returns the minute part of this DateTime. The returned value is
    /// an integer between 0 and 59.
    /// </summary>
    public int Minute => (int)((UTicks / TicksPerMinute) % 60);



    /// <summary>
    /// // Returns the second part of this DateTime. The returned value is
    /// an integer between 0 and 59.
    /// </summary>
    public int Second => (int)((UTicks / TicksPerSecond) % 60);


    /// <summary>
    /// Returns the tick count for this DateTime. The returned value is
    /// the number of 100-nanosecond intervals that have elapsed since 1/1/0001
    /// 12:00am.
    /// </summary>
    public readonly long Ticks => (long)(_dateData & TicksMask);


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

    public DateTime(int year, int month, int day)
    {
        this._dateData = DateToTicks(year, month, day);
    }


    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        this._dateData = Init(year, month, day, hour, minute, second, millisecond, DateTimeKind.Unspecified);
    }


    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind)
    {
        this._dateData = DateTime.Init(year, month, day, hour, minute, second, millisecond, kind);
    }

    private static ulong Init(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind = DateTimeKind.Unspecified)
    {
        if (millisecond >= 1000)
        {
            //DateTime.ThrowMillisecondOutOfRange();
        }
        if (kind > DateTimeKind.Local)
        {
            //DateTime.ThrowInvalidKind();
        }
        if (second != 60 || !SystemSupportsLeapSeconds)
        {
            ulong num = DateToTicks(year, month, day) + DateTime.TimeToTicks(hour, minute, second);
            num += (ulong)(millisecond * 10000);
            return num | (ulong)((ulong)((long)kind) << 62);
        }
        DateTime dateTime = new(year, month, day, hour, minute, 59, millisecond, kind);
        //if (!DateTime.IsValidTimeWithLeapSeconds(year, month, day, hour, 59, kind))
        //{
        //    ThrowHelper.ThrowArgumentOutOfRange_BadHourMinuteSecond();
        //}
        return dateTime._dateData;
    }

    private static ulong TimeToTicks(int hour, int minute, int second)
    {
        if (hour >= 24 || minute >= 60 || second >= 60)
        {
            //ThrowHelper.ThrowArgumentOutOfRange_BadHourMinuteSecond();
        }
        int num = hour * 3600 + minute * 60 + second;
        return (ulong)num * 10000000UL;
    }

    public static bool IsLeapYear(int year)
    {
        if (year < 1 || year > 9999)
        {
            //ThrowHelper.ThrowArgumentOutOfRange_Year();
        }
        return (year & 3) == 0 && ((year & 15) == 0 || year % 25 != 0);
    }

    private unsafe static ulong DateToTicks(int year, int month, int day)
    {
        if (year < 1 || year > 9999 || month < 1 || month > 12 || day < 1)
        {
            //ThrowHelper.ThrowArgumentOutOfRange_BadYearMonthDay();
        }
        ReadOnlySpan<uint> readOnlySpan = (IsLeapYear(year) ? DaysToMonth366 : DateTime.DaysToMonth365);
        if (day > (int)(readOnlySpan[month] - readOnlySpan[month - 1]))
        {
            //ThrowHelper.ThrowArgumentOutOfRange_BadYearMonthDay();
        }
        uint num = DaysToYear((uint)year) + readOnlySpan[month - 1] + (uint)day - 1U;
        return num * 864000000000UL;
    }

    private static uint DaysToYear(uint year)
    {
        uint num = year - 1U;
        uint num2 = num / 100U;
        return num * 1461U / 4U - num2 + num2 / 4U;
    }

}

public enum DateTimeKind
{
    Unspecified = 0,
    Utc = 1,
    Local = 2,
}