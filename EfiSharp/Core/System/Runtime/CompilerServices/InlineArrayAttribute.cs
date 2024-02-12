
namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
public sealed class InlineArrayAttribute(int length) : Attribute
{
    public int Length { get; set; } = length;
}
