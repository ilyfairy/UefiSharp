namespace EFI.BootServices;

/// <summary>
/// Checks whether an event is in the signaled state.
/// </summary>
public unsafe readonly struct EFI_CHECK_EVENT_Delegate(delegate* unmanaged<EFI_EVENT, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_EVENT, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Checks whether an event is in the signaled state.
    /// </summary>
    /// <param name="Event">The event to check.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The event is in the signaled state.<br/>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The event is not in the signaled state.<br/>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> Event is of type EVT_NOTIFY_SIGNAL.
    /// </returns>
    public EFI_STATUS Invoke(EFI_EVENT Event)
        => FunctionPointer(Event);
}
