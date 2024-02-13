using System.Runtime.CompilerServices;

namespace System;

public unsafe class String : System.Object
{
    [Intrinsic]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static readonly string Empty;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private readonly int _stringLength;

    public int Length => _stringLength;

    private char _firstChar;

    [IndexerName("Chars")]
    public char this[int index]
    {
        [Intrinsic]
        get
        {
            //if ((uint)index >= (uint)_stringLength)
            //    ThrowHelper.ThrowIndexOutOfRangeException();
            return Unsafe.Add(ref _firstChar, (nint)(uint)index /* force zero-extension */);
        }
    }


    //[Intrinsic]
    //public ref char get_Chars(int index)
    //{
    //    return ref Unsafe.Add(ref _firstChar, index);
    //}

    public ref char GetPinnableReference() => ref _firstChar;

    //public static string Format(string format)
    //{

    //}

    public static bool Equals(char* left, char* right)
    {
        int index = 0;
        while (true)
        {
            var a = left[index];
            var b = right[index];
            index++;

            if(a == '\0' && b == '\0')
                return true;

            if(a != b)
                return false;
        }
    }


    public static bool Equals(char* left, string right)
    {
        fixed(char* rightPtr = right)
            return Equals(left, rightPtr);
    }

    public static bool Equals(string left, char* right)
    {
        fixed(char* leftPtr = left)
            return Equals(leftPtr, right);
    }
}
