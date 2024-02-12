using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public unsafe ref struct ReadOnlySpan<T>
{
    /// <summary>A byref or a native ptr.</summary>
    internal readonly T* _reference;
    /// <summary>The number of elements this ReadOnlySpan contains.</summary>
    private readonly int _length;

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
