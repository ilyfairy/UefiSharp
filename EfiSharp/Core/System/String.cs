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
