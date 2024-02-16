namespace EFI.BootServices;

/// <summary>
/// Closes an event.
/// </summary>
public unsafe readonly struct EFI_CLOSE_EVENT_Delegate(delegate* unmanaged<EFI_EVENT, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_EVENT, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Closes an event.
    /// </summary>
    /// <param name="Event">The event to close.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The event has been closed.<br/>
    /// </returns>
    public EFI_STATUS Invoke(EFI_EVENT Event)
        => FunctionPointer(Event);
}
