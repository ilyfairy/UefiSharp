using System.Runtime.InteropServices;

namespace EFI.Times;

[StructLayout(LayoutKind.Sequential)]
public struct EFI_TIME
{
    /// <summary>
    /// 1900 - 9999
    /// </summary>
    public ushort Year;

    /// <summary>
    /// 1 - 12
    /// </summary>
    public byte Month;

    /// <summary>
    /// 1 - 31
    /// </summary>
    public byte Day;

    /// <summary>
    /// 0 - 23
    /// </summary>
    public byte Hour;

    /// <summary>
    /// 0 - 59
    /// </summary>
    public byte Minute;

    /// <summary>
    /// 0 - 59
    /// </summary>
    public byte Second;

    public byte Pad1;

    /// <summary>
    /// 0 - 999,999,999
    /// </summary>
    public uint Nanosecond;

    /// <summary>
    /// -1440 to 1440 or 2047
    /// </summary>
    public ushort TimeZone;

    public byte Daylight;

    public byte Pad2;
}
