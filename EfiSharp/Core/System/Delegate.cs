#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace System;

public class Delegate
{
    internal object m_firstParameter;
    internal object m_helperObject;
    internal nint m_extraFunctionPointerOrData;
    internal IntPtr m_functionPointer;


    private void InitializeClosedInstance(object firstParameter, IntPtr functionPointer)
    {
        //if (firstParameter is null)
        //    throw new ArgumentException(SR.Arg_DlgtNullInst);

        m_functionPointer = functionPointer;
        m_firstParameter = firstParameter;
    }
}

public class MulticastDelegate : Delegate
{

}

public delegate void Action();