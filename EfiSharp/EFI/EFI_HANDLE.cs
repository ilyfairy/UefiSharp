using System;
using System.Runtime.InteropServices;

namespace EFI;

[StructLayout(LayoutKind.Sequential)]
public struct EFI_HANDLE
{
    private IntPtr _handle;
}
