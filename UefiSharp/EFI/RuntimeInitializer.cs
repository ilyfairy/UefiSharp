using System;
using System.Runtime.InteropServices;

namespace EFI;

public static class RuntimeInitializer
{
    public static unsafe void Initialize(IntPtr imageHandle, EFI_SYSTEM_TABLE* systemTable)
    {
        Console.Initialize(systemTable);
        DateTime.Initialize(systemTable->RuntimeServices);
        NativeMemory.Initialize(systemTable);
    }
}
