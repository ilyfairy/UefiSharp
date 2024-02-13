#pragma warning disable

using System;
using System.Runtime.CompilerServices;

namespace System;
public struct Void;
public class ValueType;
public class Enum;

public struct Byte;
public struct SByte;
public struct Boolean
{
    public const bool True = true;
    public const bool False = false;

    public byte _value;

    public override string ToString()
    {
        if(_value == 0)
            return "False";
        else
            return "True";
    }
}
public struct Char;
public struct Int16;
public struct UInt16;
public struct Int32
{
    public const int MaxValue = 0x7fffffff;
    public const int MinValue = unchecked((int)0x80000000);
}
public struct UInt32
{
    public const uint MaxValue = (uint)0xffffffff;
    public const uint MinValue = 0U;
}
public struct Int64
{
    public const long MaxValue = 0x7fffffffffffffffL;
    public const long MinValue = unchecked((long)0x8000000000000000L);
}
public struct UInt64
{
    public const ulong MaxValue = (ulong)0xffffffffffffffffL;
    public const ulong MinValue = 0x0;
}
public struct Signal;
public struct Double;


public struct Nullable<T> where T : struct { }

public class FlagsAttribute : Attribute;