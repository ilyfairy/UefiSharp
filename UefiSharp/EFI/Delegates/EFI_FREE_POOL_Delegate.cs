namespace EFI.Delegates;

/// <summary>
/// Returns pool memory to the system.
/// </summary>
public unsafe readonly struct EFI_FREE_POOL_Delegate(delegate* unmanaged<nint, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<nint, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Returns pool memory to the system.
    /// </summary>
    /// <param name="Buffer">The pointer to the buffer to free.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The memory was returned to the system.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/> Buffer was invalid.<br/>
    /// </returns>
    public EFI_STATUS Invoke(nint Buffer) => FunctionPointer(Buffer);
    public EFI_STATUS Invoke(void* Buffer) => FunctionPointer((nint)Buffer);
}
