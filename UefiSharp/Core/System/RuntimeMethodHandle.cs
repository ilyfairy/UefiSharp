namespace System;

public struct RuntimeMethodHandle
{
    private readonly IRuntimeMethodInfo m_value;
}
internal interface IRuntimeMethodInfo
{
    RuntimeMethodHandleInternal Value { get; }
}

internal struct RuntimeMethodHandleInternal
{
    internal IntPtr m_handle;
}