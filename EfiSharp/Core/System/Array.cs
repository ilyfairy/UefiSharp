using System.Runtime.CompilerServices;

namespace System;

public unsafe abstract class Array
{
    public int Length { get; }
}

public unsafe class Array<T> : Array
{

    //public void* GetPointer()
    //{
    //    //Array* a = &this;
    //}
}
