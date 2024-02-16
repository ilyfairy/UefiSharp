namespace EFI.BootServices;

/// <summary>
/// Signals an event.
/// </summary>
public unsafe readonly struct EFI_SIGNAL_EVENT_Delegate(delegate* unmanaged<EFI_EVENT, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_EVENT, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Signals an event.
    /// </summary>
    /// <param name="Event">The event to signal.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The event has been signaled.<br/>
    /// </returns>
    public EFI_STATUS Invoke(EFI_EVENT Event)
        => FunctionPointer(Event);
}
