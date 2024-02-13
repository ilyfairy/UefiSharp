namespace EFI;

/// <summary>
/// Task priority level.
/// </summary>
public struct EFI_TPL(nuint value)
{
    public nuint Value { get; set; } = value;

    public static implicit operator nuint(EFI_TPL tpl) => tpl.Value;
    public static implicit operator EFI_TPL(nuint value) => new EFI_TPL(value);
}