#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public unsafe ref struct Span<T>
{
    /// <summary>A byref or a native ptr.</summary>
    internal readonly T* _reference;
    /// <summary>The number of elements this ReadOnlySpan contains.</summary>
    private readonly int _length;

    public readonly int Length => _length;

    public T this[int index]
    {
        get => _reference[index];
        set => _reference[index] = value;
    }

    public Span(T[]? array)
    {
        if (array == null)
        {
            this = default;
            return; // returns default
        }

        //_reference = ref MemoryMarshal.GetArrayDataReference(array);
        _reference = (T*)Unsafe.AsPointer(ref array[0]);
        _length = array.Length;
    }

    public Span(void* ptr, int length)
    {
        _reference = (T*)ptr;
        _length = length;
    }

    public void Clear()
    {
        var size = sizeof(T) * _length;
        NativeMemory.Clear(_reference, Unsafe.As<int, nuint>(ref size));
    }

    public static implicit operator T* (Span<T> span) => span._reference;

    public static bool operator ==(Span<T> left, Span<T> right)
    {
        if (left.Length != right.Length)
            return false;

        if(left._reference == right._reference)
            return true;

        return true;
    }

    public static bool operator !=(Span<T> left, Span<T> right) => !(left == right);
}
