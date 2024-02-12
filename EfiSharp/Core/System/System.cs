#pragma warning disable

using System;
using System.Runtime.CompilerServices;

namespace System;
public struct Void;
public class ValueType;
public class Enum;

public struct Byte;
public struct SByte;
public struct Boolean;
public struct Char;
public struct Int16;
public struct UInt16;
public struct Int32
{
    public const int MaxValue = 0x7fffffff;
    public const int MinValue = unchecked((int)0x80000000);
}
public struct UInt32;
public struct Int64;
public struct UInt64;
public struct Signal;
public struct Double;


public struct Nullable<T> where T : struct { }

public class FlagsAttribute : Attribute;