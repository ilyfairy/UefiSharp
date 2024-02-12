using System.Runtime.CompilerServices;

namespace System;

public unsafe class String : System.Object
{
    public const string Empty = "";
    private readonly int _stringLength;

    public int Length => _stringLength;

    private char _firstChar;

    public ref char this[int index]
    {
        get => ref Unsafe.Add(ref _firstChar, index);
    }

    public ref char GetPinnableReference() => ref _firstChar;

    //public static string Format(string format)
    //{

    //}

}
