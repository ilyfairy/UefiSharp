namespace EFI.Delegates;

/// <summary>
/// Raises a task's priority level and returns its previous level.
/// </summary>
public unsafe readonly struct EFI_RAISE_TPL_Delegate(delegate* unmanaged<EFI_TPL, nuint> fp)
{
    public readonly delegate* unmanaged<EFI_TPL, nuint> FunctionPointer = fp;

    /// <summary>
    /// Raises a task's priority level and returns its previous level.
    /// </summary>
    /// <param name="NewTpl">The new task priority level.</param>
    /// <returns>Previous task priority level</returns>
    public EFI_TPL Invoke(nuint NewTpl) => FunctionPointer(NewTpl);
}
