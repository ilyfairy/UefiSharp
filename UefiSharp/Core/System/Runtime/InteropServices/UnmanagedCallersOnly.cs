#pragma warning disable

using System;
using System.Runtime;
using System.Runtime.InteropServices;

namespace System.Runtime.InteropServices;

public class UnmanagedCallersOnly : Attribute
{
    public string EntryPoint;
    public Type[] CallConvs;
}
