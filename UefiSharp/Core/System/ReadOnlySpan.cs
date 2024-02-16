#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly ref struct ReadOnlySpan<T>
{
    /// <summary>A byref or a native ptr.</summary>
    internal readonly T* _reference;
    /// <summary>The number of elements this ReadOnlySpan contains.</summary>
    private readonly int _length;

    public ref readonly T this[int index]
    {
        get => ref _reference[index];
    }

    public ReadOnlySpan(ref readonly T ptr, int length)
    {
        _reference = (T*)Unsafe.AsPointer(ref Unsafe.AsRef(ptr));
        _length = length;
    }

    public ReadOnlySpan(T[]? array)
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
}
