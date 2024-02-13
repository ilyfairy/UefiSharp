using Internal.Runtime;

namespace System;

public unsafe struct EETypePtr
{
    private MethodTable* _value;


    public EETypePtr(IntPtr value)
    {
        _value = (MethodTable*)value;
    }

    internal EETypePtr(MethodTable* value)
    {
        _value = value;
    }

    // Caution: You cannot safely compare RawValue's as RH does NOT unify EETypes. Use the == or Equals() methods exposed by EETypePtr itself.
    internal IntPtr RawValue
    {
        get
        {
            return (IntPtr)_value;
        }
    }

}
