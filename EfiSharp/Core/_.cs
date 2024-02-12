#pragma warning disable

using System;
using System.Runtime;

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
}