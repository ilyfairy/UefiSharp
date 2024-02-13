#pragma warning disable

using System.Runtime.CompilerServices;

namespace System;

public class Object
{
    private IntPtr m_pMethodTable;
    ~Object() { }

    public virtual string ToString()
    {
        return string.Empty;
    }

    public virtual bool Equals(object? obj) => this == obj;
    public virtual int GetHashCode() => 0;

    [Intrinsic]
    public extern Type GetType();

    public unsafe void* GetPointer()
    {
        return Unsafe.AsPointer(ref Unsafe.AsRef(this));
    }
}
