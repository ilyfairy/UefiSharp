#pragma warning disable

using System;
using System.Runtime.CompilerServices;

namespace System;

public unsafe struct IntPtr
{
    private readonly nint _value;

    [Intrinsic]
    public static readonly nint Zero;

    public static nint MaxValue => sizeof(nint) == 8 ? (nint)long.MaxValue : int.MaxValue;

    public IntPtr(int value)
    {
        _value = (IntPtr)value;
    }

    public static IntPtr operator +(IntPtr pointer, int offset) => (IntPtr)((long)pointer + (long)offset);

    public static explicit operator void*(IntPtr value) => *(void**)&value;

    public static explicit operator IntPtr(void* value) => *(IntPtr*)&value;

    public static explicit operator IntPtr(int value)
    {
        long val = value;
        return *(IntPtr*)&val;
    }

    public static explicit operator IntPtr(long value) => (IntPtr)value;

    public static explicit operator long(IntPtr value) => *(long*)&value;

    public static explicit operator IntPtr(UIntPtr value) => Unsafe.As<UIntPtr, IntPtr>(ref value);

    public static bool operator <(IntPtr left, nint right) => left._value < right;
    public static bool operator >(IntPtr left, nint right) => left._value > right;
}

public unsafe struct UIntPtr
{
    private readonly UIntPtr _value;

    public static UIntPtr operator +(UIntPtr pointer, int offset) => (UIntPtr)((ulong)pointer + (ulong)offset);

    public static explicit operator void*(UIntPtr value) => *(void**)&value;

    public static explicit operator UIntPtr(void* value) => *(UIntPtr*)&value;

    public static explicit operator UIntPtr(uint value)
    {
        ulong val = value;
        return *(UIntPtr*)&val;
    }

    public static explicit operator UIntPtr(ulong value) => (UIntPtr)value;

    public static explicit operator ulong(UIntPtr value) => *(ulong*)&value;

    public static explicit operator UIntPtr(IntPtr value) => Unsafe.As<IntPtr, UIntPtr>(ref value);

}