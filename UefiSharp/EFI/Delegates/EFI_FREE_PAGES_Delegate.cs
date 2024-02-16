namespace EFI.Delegates;

/// <summary>
/// Frees memory pages.
/// </summary>
public unsafe readonly struct EFI_FREE_PAGES_Delegate(delegate* unmanaged<nuint, nuint, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<nuint, nuint, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Frees memory pages.
    /// </summary>
    /// <param name="Pages">The base physical address of the pages to be freed.</param>
    /// <param name="Memory">The number of contiguous 4 KB pages to free.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The requested pages were freed.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/> Memory is not a page-aligned address or Pages is invalid.<br/>
    /// <see cref="EFI_STATUS.EFI_NOT_FOUND"/> The requested memory pages were not allocated with AllocatePages().
    /// </returns>
    public EFI_STATUS Invoke(nuint Memory, nuint Pages) => FunctionPointer(Memory, Pages);
}
