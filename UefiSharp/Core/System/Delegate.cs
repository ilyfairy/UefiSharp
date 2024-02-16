#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.Runtime.CompilerServices;

namespace System;

public unsafe class Delegate
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

    // This function is known to the compiler backend.
    private void InitializeClosedStaticThunk(object firstParameter, IntPtr functionPointer, IntPtr functionPointerThunk)
    {
        m_extraFunctionPointerOrData = functionPointer;
        m_helperObject = firstParameter;
        m_functionPointer = functionPointerThunk;
        m_firstParameter = this;
    }

    // This function is known to the compiler backend.
    private void InitializeOpenStaticThunk(object _ /*firstParameter*/, IntPtr functionPointer, IntPtr functionPointerThunk)
    {
        // This sort of delegate is invoked by calling the thunk function pointer with the arguments to the delegate + a reference to the delegate object itself.
        m_firstParameter = this;
        m_functionPointer = functionPointerThunk;
        m_extraFunctionPointerOrData = functionPointer;
    }

    public nint GetManagedFunctionPointer()
    {
        //Console.Write("m_firstParameter: ");
        //Console.WriteLine(*(nint*)Unsafe.AsPointer(ref m_firstParameter));

        //Console.Write("m_helperObject: ");
        //Console.WriteLine(*(nint*)Unsafe.AsPointer(ref m_helperObject));

        //Console.Write("m_extraFunctionPointerOrData: ");
        //Console.WriteLine(m_extraFunctionPointerOrData);

        //Console.Write("m_functionPointer: ");
        //Console.WriteLine(m_functionPointer);

        //((delegate* unmanaged<void>)*(nint*)Unsafe.AsPointer(ref m_firstParameter))();
        //((delegate* unmanaged<void>)*(nint*)Unsafe.AsPointer(ref m_helperObject))();
        //((delegate* unmanaged<void>)m_extraFunctionPointerOrData)();
        //((delegate* unmanaged<void>)m_functionPointer)();

        return m_extraFunctionPointerOrData;
    }
}

public class MulticastDelegate : Delegate
{

}

public delegate void Action();