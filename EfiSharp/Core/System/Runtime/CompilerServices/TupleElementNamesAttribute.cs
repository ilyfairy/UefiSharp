using System.Collections.Generic;

namespace System.Runtime.CompilerServices;

public class TupleElementNamesAttribute(string[] transformNames) : Attribute
{
    public IList<string> TransformNames { get; } = transformNames;
}
