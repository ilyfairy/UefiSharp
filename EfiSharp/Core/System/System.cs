#pragma warning disable

using System;
using System.Runtime.CompilerServices;

namespace System;
public struct Void;
public class ValueType;
public class Enum;

public struct Byte;
public struct SByte;
public struct Boolean;
public struct Char;
public struct Int16;
public struct UInt16;
public struct Int32
{
    public const int MaxValue = 0x7fffffff;
    public const int MinValue = unchecked((int)0x80000000);
}
public struct UInt32;
public struct Int64;
public struct UInt64;
public struct Signal;
public struct Double;
public unsafe struct IntPtr
{
    private readonly IntPtr _value;

    public static IntPtr operator +(IntPtr pointer, int offset)
    {
        return (IntPtr)((long)pointer + (long)offset);
    }

    public static explicit operator void*(IntPtr value)
    {
        return *(void**)&value;
    }

    public static explicit operator IntPtr(void* value)
    {
        return *(IntPtr*)&value;
    }

    public static explicit operator IntPtr(int value)
    {
        long val = value;
        return *(IntPtr*)&val;
    }

    public static explicit operator IntPtr(long value)
    {
        return (IntPtr)value;
    }

    public static explicit operator long(IntPtr value)
    {
        return *(long*)&value;
    }

}
public struct UIntPtr;

public struct Nullable<T> where T : struct { }

public class FlagsAttribute : Attribute;