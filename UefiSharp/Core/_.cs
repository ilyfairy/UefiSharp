#pragma warning disable

using System.Runtime;
using System.Runtime.InteropServices;
using Internal;
using Internal.Runtime;

namespace System;

internal unsafe class StartupCodeHelpersBalabala
{
    [RuntimeExport("RhpReversePInvoke")]
    static void RhpReversePInvoke(IntPtr frame) { }

    [RuntimeExport("RhpReversePInvokeReturn")]
    static void RhpReversePInvokeReturn(IntPtr frame) { }

    [RuntimeExport("RhpPInvoke")]
    static void RhpPInvoke(IntPtr frame) { }

    [RuntimeExport("RhpPInvokeReturn")]
    static void RhpPInvokeReturn(IntPtr frame) { }

    [RuntimeExport("RhpFallbackFailFast")]
    static void RhpFallbackFailFast() { while (true) ; }


    [RuntimeExport("RhpThrowEx")]
    static void RhpThrowEx(object exception)
    {
        Console.WriteLine("Exception!");
    }

    [RuntimeExport("__security_cookie")]
    static void __security_cookie()
    {
        Console.WriteLine("call __security_cookie");
    }
    
    [RuntimeExport("memset")]
    static unsafe void memset(void* addr, int c, int n)
    {
        NativeMemory.Fill(addr, (nuint)n, (byte)c);
    }

    [RuntimeExport("RhSpanHelpers_MemZero")]
    static unsafe void MemZero(byte* ptr, nuint len)
    {
        for (nuint i = 0; i < len; i++)
        {
            ptr[i] = 0;
        }
    }

    [RuntimeExport("RhpNewFast")] // new Object
    static unsafe void* RhpNewFast(MethodTable* mt)
    {
        Console.WriteLine("call new");
        MethodTable** result = (MethodTable**)NativeMemory.Alloc(mt->BaseSize);
        *result = mt;
        return result;
    }

    [RuntimeExport("RhpAssignRef")]
    static unsafe void RhpAssignRef(void** address, void* obj)
    {
        Console.WriteLine("call RhpAssignRef");
        *address = obj;
    }

    [RuntimeExport("RhpNewArray")] // new Array
    static void* RhpNewArray(MethodTable* mt, int numElements)
    {
        Console.WriteLine("call RhpNewArray");

        MethodTable** result = (MethodTable**)NativeMemory.Alloc((uint)(mt->BaseSize + numElements * mt->ComponentSize));
        *result = mt;
        *(int*)(result + 1) = numElements;
        return result;
    }
}