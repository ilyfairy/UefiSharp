#pragma warning disable

using System;
using System.Runtime.CompilerServices;

namespace System;

public abstract unsafe class Type
{
    [Intrinsic]
    public static Type GetTypeFromHandle(RuntimeTypeHandle handle)
    {
        //return handle.m_type;
        return null;
    }
}

public abstract unsafe class TypeInfo
{

}

public class RuntimeType : TypeInfo
{

}

public struct RuntimeTypeHandle
{
    private IntPtr _value;

    internal RuntimeTypeHandle(EETypePtr pEEType)
        : this(pEEType.RawValue)
    {
    }

    private RuntimeTypeHandle(IntPtr value)
    {
        _value = value;
    }

}