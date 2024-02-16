namespace EFI.Delegates;

/// <summary>
/// Restores a task's priority level to its previous value.
/// </summary>
public unsafe readonly struct EFI_RESTORE_TPL_Delegate(delegate* unmanaged<EFI_TPL, void> fp)
{
    public readonly delegate* unmanaged<EFI_TPL, void> FunctionPointer = fp;

    /// <summary>
    /// Restores a task's priority level to its previous value.
    /// </summary>
    /// <param name="NewTpl">The previous task priority level to restore.</param>
    public void Invoke(EFI_TPL OldTpl) => FunctionPointer(OldTpl);
}
