
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple;

[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T>
{
    public T Item1;
    public ValueTuple(T item1) => Item1 = item1;
}

[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T, T2>
{
    public T Item1;
    public T2 Item2;

    public ValueTuple(T item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}


[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T, T2, T3>
{
    public T Item1;
    public T2 Item2;
    public T3 Item3;

    public ValueTuple(T item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
    }
}
