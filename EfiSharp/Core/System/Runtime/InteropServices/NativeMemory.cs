using EFI;
using EFI.BootServices;

namespace System.Runtime.InteropServices;

public static unsafe class NativeMemory
{
    private static EFI_SYSTEM_TABLE* systemTable;
    public static void Initialize(EFI_SYSTEM_TABLE* systemTable)
    {
        NativeMemory.systemTable = systemTable;
    }

    public static void Fill(void* ptr, nuint byteCount, byte value)
    {
        byte* bytePtr = (byte*)ptr;
        
        while (byteCount >= 8)
        {
            bytePtr[0] = value;
            bytePtr[1] = value;
            bytePtr[2] = value;
            bytePtr[3] = value;
            bytePtr[4] = value;
            bytePtr[5] = value;
            bytePtr[6] = value;
            bytePtr[7] = value;
            bytePtr += 8;
            byteCount -= 8;
        }

        while (byteCount >= 4)
        {
            bytePtr[0] = value;
            bytePtr[1] = value;
            bytePtr[2] = value;
            bytePtr[3] = value;
            bytePtr += 4;
            byteCount -= 4;
        }

        for (nuint i = 0; i < byteCount; i++)
            bytePtr[i] = value;
    }

    public static void Clear(void* ptr, nuint byteCount)
    {
        Fill(ptr, byteCount, 0);
    }

    public static void* Alloc(nuint size)
    {
        void* ptr;
        var result = systemTable->BootServices->AllocatePool.Invoke(EFI_MEMORY_TYPE.EfiLoaderData, size, &ptr);
        if (!result.IsSuccess)
        {
            Console.WriteLine("Alloc Memory Failed");
            while (true) ;
        }
        return ptr;
    }

    public static void Free(void* ptr)
    {
        systemTable->BootServices->FreePool((UIntPtr)ptr);
    }
}
