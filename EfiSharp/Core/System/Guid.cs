using System;

namespace System;

public struct Guid
{
    public static readonly Guid Empty;

    public readonly int _a;   // Do not rename (binary serialization)
    public readonly short _b; // Do not rename (binary serialization)
    public readonly short _c; // Do not rename (binary serialization)
    public readonly byte _d;  // Do not rename (binary serialization)
    public readonly byte _e;  // Do not rename (binary serialization)
    public readonly byte _f;  // Do not rename (binary serialization)
    public readonly byte _g;  // Do not rename (binary serialization)
    public readonly byte _h;  // Do not rename (binary serialization)
    public readonly byte _i;  // Do not rename (binary serialization)
    public readonly byte _j;  // Do not rename (binary serialization)
    public readonly byte _k;  // Do not rename (binary serialization)
}
