namespace System.Runtime.InteropServices;

public class FieldOffsetAttribute(int offset) : Attribute
{
    public int Value { get; } = offset;
}
