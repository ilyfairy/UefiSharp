using System;

namespace Internal.Runtime.CompilerHelpers;

public static class ThrowHelpers
{
    public static void ThrowPlatformNotSupportedException()
    {
        Console.WriteLine("ThrowPlatformNotSupportedException");
    }

    public static void ThrowIndexOutOfRangeException()
    {
        Console.WriteLine("ThrowIndexOutOfRangeException");
    }

    public static void ThrowInvalidProgramException()
    {
        Console.WriteLine("ThrowInvalidProgramException");
    }

    public static void ThrowInvalidProgramExceptionWithArgument()
    {
        Console.WriteLine("ThrowInvalidProgramExceptionWithArgument");
    }
}
