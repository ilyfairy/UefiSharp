using System;

namespace EFI;

public static class RuntimeInitializer
{
    public static unsafe void Initialize(IntPtr imageHandle, EFI_SYSTEM_TABLE* systemTable)
    {
        Console.Initialize(systemTable);
    }
}
