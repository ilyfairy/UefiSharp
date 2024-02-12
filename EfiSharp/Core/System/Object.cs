#pragma warning disable

namespace System;

public class Object
{
    private IntPtr m_pMethodTable;

    public virtual string ToString()
    {
        return string.Empty;
    }
}
