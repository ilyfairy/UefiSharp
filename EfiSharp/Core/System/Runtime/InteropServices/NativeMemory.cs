using System;

namespace Core.System.Runtime.InteropServices;

public static unsafe class NativeMemory
{
    public static void Fill(void* ptr, nuint byteCount, byte value)
    {
        byte* bytePtr = (byte*)ptr;
        for (nuint i = 0; i < byteCount; i++)
        {
            bytePtr[i] = value;
        }
    }

    public static void Clear(void* ptr, nuint byteCount)
    {
        Fill(ptr, byteCount, 0);
    }
}
