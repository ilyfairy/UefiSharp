#pragma warning disable

using System;
using System.Runtime;
using Core.System.Runtime.InteropServices;

namespace System;

internal class StartupCodeHelpersBalabala
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
    



    [RuntimeExport("__security_cookie")]
    static void __security_cookie() { }
    

    [RuntimeExport("memset")]
    static unsafe void memset(void* addr, int c, int n)
    {
        NativeMemory.Fill(addr, (nuint)n, (byte)c);
    }
}