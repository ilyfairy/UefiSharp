#pragma warning disable

using System;
using System.Runtime;
using System.Runtime.InteropServices;

namespace System.Runtime.InteropServices;

public sealed class StructLayoutAttribute(LayoutKind layoutKind) : Attribute
{
    public int Pack;

    public int Size;

    public CharSet CharSet;
}
