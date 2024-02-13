#pragma warning disable

using System;
using System.Runtime.CompilerServices;

namespace System;

public abstract unsafe class Type
{
    public abstract Guid GUID { get; }

    [Intrinsic]
    public static Type GetTypeFromHandle(RuntimeTypeHandle handle)
    {
        //return handle.m_type;
        return null;
    }
}

public abstract unsafe class TypeInfo : Type
{

}

public class RuntimeType : TypeInfo
{
    [Intrinsic]
    //[MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetGUID(ref Guid result);

    public override Guid GUID
    {
        get
        {
            Guid guid = default(Guid);
            this.GetGUID(ref guid);
            return guid;
        }
    }

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