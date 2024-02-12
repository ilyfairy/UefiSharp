using System;
using System.Runtime.InteropServices;
using EFI.BootServices;
using EFI.RuntimeServices;

namespace EFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct EFI_SYSTEM_TABLE
{
    public readonly EFI_TABLE_HEADER Hdr;
    public readonly char* FirmwareVendor;
    public readonly uint FirmwareRevision;
    public readonly EFI_HANDLE ConsoleInHandle;
    public readonly EFI_SIMPLE_TEXT_INPUT_PROTOCOL* ConIn;
    public readonly EFI_HANDLE ConsoleOutHandle;
    public readonly EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* ConOut;
    public readonly EFI_HANDLE StandardErrorHandle;
    public readonly EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* StdErr;
    public readonly EFI_RUNTIME_SERVICES* RuntimeServices;
    public readonly EFI_BOOT_SERVICES* BootServices;
    public readonly IntPtr NumberOfTableEntries;
    public readonly EFI_CONFIGURATION_TABLE ConfigurationTable;
}
