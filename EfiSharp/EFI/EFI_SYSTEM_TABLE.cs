using System;
using System.Runtime.InteropServices;
using EFI.BootServices;
using EFI.RuntimeServices;

namespace EFI;

/// <summary>
/// EFI System Table
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct EFI_SYSTEM_TABLE
{
    /// <summary>
    /// The table header for the EFI System Table.
    /// </summary>
    public readonly EFI_TABLE_HEADER Hdr;

    /// <summary>
    /// A pointer to a null terminated string that identifies the vendor
    /// that produces the system firmware for the platform.
    /// </summary>
    public readonly char* FirmwareVendor;

    /// <summary>
    /// A firmware vendor specific value that identifies the revision
    /// of the system firmware for the platform.
    /// </summary>
    public readonly uint FirmwareRevision;

    /// <summary>
    /// The handle for the active console input device. This handle must support
    /// EFI_SIMPLE_TEXT_INPUT_PROTOCOL and EFI_SIMPLE_TEXT_INPUT_EX_PROTOCOL.
    /// </summary>
    public readonly EFI_HANDLE ConsoleInHandle;

    /// <summary>
    /// A pointer to the EFI_SIMPLE_TEXT_INPUT_PROTOCOL interface that is
    /// associated with ConsoleInHandle.
    /// </summary>
    public readonly EFI_SIMPLE_TEXT_INPUT_PROTOCOL* ConIn;

    /// <summary>
    /// The handle for the active console output device.
    /// </summary>
    public readonly EFI_HANDLE ConsoleOutHandle;

    /// <summary>
    /// A pointer to the EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL interface
    /// that is associated with ConsoleOutHandle.
    /// </summary>
    public readonly EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* ConOut;

    /// <summary>
    /// The handle for the active standard error console device.
    /// This handle must support the EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL.
    /// </summary>
    public readonly EFI_HANDLE StandardErrorHandle;

    /// <summary>
    /// A pointer to the EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL interface
    /// that is associated with StandardErrorHandle.
    /// </summary>
    public readonly EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* StdErr;

    /// <summary>
    /// A pointer to the EFI Runtime Services Table.
    /// </summary>
    public readonly EFI_RUNTIME_SERVICES* RuntimeServices;

    /// <summary>
    /// A pointer to the EFI Boot Services Table.
    /// </summary>
    public readonly EFI_BOOT_SERVICES* BootServices;

    /// <summary>
    /// The number of system configuration tables in the buffer ConfigurationTable.
    /// </summary>
    public readonly nuint NumberOfTableEntries;

    /// <summary>
    /// A pointer to the system configuration tables.
    /// The number of entries in the table is NumberOfTableEntries.
    /// </summary>
    public readonly EFI_CONFIGURATION_TABLE ConfigurationTable;
}
