namespace System;

public struct RuntimeFieldHandle
{
    private IRuntimeFieldInfo m_ptr;
}

internal interface IRuntimeFieldInfo
{
    // Token: 0x170000B3 RID: 179
    // (get) Token: 0x0600094D RID: 2381
    RuntimeFieldHandleInternal Value { get; }
}

internal struct RuntimeFieldHandleInternal
{
    internal IntPtr m_handle;
}