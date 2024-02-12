using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Core.System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public unsafe ref struct Span<T>
{
    /// <summary>A byref or a native ptr.</summary>
    internal readonly T* _reference;
    /// <summary>The number of elements this ReadOnlySpan contains.</summary>
    private readonly int _length;

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
}
