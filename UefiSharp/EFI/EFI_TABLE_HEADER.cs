using System.Runtime.InteropServices;

namespace EFI;

/// <summary>
/// Data structure that precedes all of the standard EFI table types.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct EFI_TABLE_HEADER
{
    /// <summary>
    /// A 64-bit signature that identifies the type of table that follows.
    /// Unique signatures have been generated for the EFI System Table,
    /// the EFI Boot Services Table, and the EFI Runtime Services Table.
    /// </summary>
    public readonly ulong Signature;

    /// <summary>
    /// The revision of the EFI Specification to which this table
    /// conforms. The upper 16 bits of this field contain the major
    /// revision value, and the lower 16 bits contain the minor revision
    /// value. The minor revision values are limited to the range of 00..99.
    /// </summary>
    public readonly uint Revision;

    /// <summary>
    /// The size, in bytes, of the entire table including the EFI_TABLE_HEADER.
    /// </summary>
    public readonly uint HeaderSize;

    /// <summary>
    /// The 32-bit CRC for the entire table. This value is computed by
    /// setting this field to 0, and computing the 32-bit CRC for HeaderSize bytes.
    /// </summary>
    public readonly uint Crc32;

    /// <summary>
    /// Reserved field that must be set to 0.
    /// </summary>
    public readonly uint Reserved;
}
