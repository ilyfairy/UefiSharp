#pragma warning disable

using System;
using System.Runtime.CompilerServices;

namespace System;

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

public unsafe struct UIntPtr
{
    private readonly UIntPtr _value;

    public static UIntPtr operator +(UIntPtr pointer, int offset)
    {
        return (UIntPtr)((ulong)pointer + (ulong)offset);
    }

    public static explicit operator void*(UIntPtr value)
    {
        return *(void**)&value;
    }

    public static explicit operator UIntPtr(void* value)
    {
        return *(UIntPtr*)&value;
    }

    public static explicit operator UIntPtr(uint value)
    {
        ulong val = value;
        return *(UIntPtr*)&val;
    }

    public static explicit operator UIntPtr(ulong value)
    {
        return (UIntPtr)value;
    }

    public static explicit operator ulong(UIntPtr value)
    {
        return *(ulong*)&value;
    }
}