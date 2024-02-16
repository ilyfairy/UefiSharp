namespace EFI.BootServices;

/// <summary>
/// Handle to an event structure.
/// </summary>
public unsafe struct EFI_EVENT
{
    public void* Value;

    public static implicit operator EFI_EVENT(void* value) => new() { Value = value };
}