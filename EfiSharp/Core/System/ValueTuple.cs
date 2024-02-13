
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
public struct ValueTuple<T, T2>(T item1, T2 item2)
{
    public T Item1 = item1;
    public T2 Item2 = item2;
}


[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T, T2, T3>(T item1, T2 item2, T3 item3)
{
    public T Item1 = item1;
    public T2 Item2 = item2;
    public T3 Item3 = item3;
}


[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T, T2, T3, T4>(T item1, T2 item2, T3 item3, T4 item4)
{
    public T Item1 = item1;
    public T2 Item2 = item2;
    public T3 Item3 = item3;
    public T4 Item4 = item4;
}

[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T, T2, T3, T4, T5>(T item1, T2 item2, T3 item3, T4 item4, T5 item5)
{
    public T Item1 = item1;
    public T2 Item2 = item2;
    public T3 Item3 = item3;
    public T4 Item4 = item4;
    public T5 Item5 = item5;
}

[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T, T2, T3, T4, T5, T6>(T item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
{
    public T Item1 = item1;
    public T2 Item2 = item2;
    public T3 Item3 = item3;
    public T4 Item4 = item4;
    public T5 Item5 = item5;
    public T6 Item6 = item6;
}

[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T, T2, T3, T4, T5, T6, T7>(T item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
{
    public T Item1 = item1;
    public T2 Item2 = item2;
    public T3 Item3 = item3;
    public T4 Item4 = item4;
    public T5 Item5 = item5;
    public T6 Item6 = item6;
    public T7 Item7 = item7;
}

[StructLayout(LayoutKind.Sequential)]
public struct ValueTuple<T, T2, T3, T4, T5, T6, T7, TRest>(T item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
    where TRest : struct
{
    public T Item1 = item1;
    public T2 Item2 = item2;
    public T3 Item3 = item3;
    public T4 Item4 = item4;
    public T5 Item5 = item5;
    public T6 Item6 = item6;
    public T7 Item7 = item7;
    public TRest Rest = rest;
}
