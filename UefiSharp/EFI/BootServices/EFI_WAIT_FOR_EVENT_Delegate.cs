namespace EFI.BootServices;

/// <summary>
/// Stops execution until an event is signaled.
/// </summary>
public unsafe readonly struct EFI_WAIT_FOR_EVENT_Delegate(delegate* unmanaged<nuint, EFI_EVENT, nuint, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<nuint, EFI_EVENT, nuint, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Stops execution until an event is signaled.
    /// </summary>
    /// <param name="NumberOfEvents">The number of events in the Event array.</param>
    /// <param name="Event">An array of EFI_EVENT.</param>
    /// <param name="Index">The pointer to the index of the event which satisfied the wait condition.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The event has been set to be signaled at the requested time.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/><br/>
    /// 1) NumberOfEvents is 0.<br/>
    /// 2) The event indicated by Index is of type EVT_NOTIFY_SIGNAL.<br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> The current TPL is not TPL_APPLICATION.<br/>
    /// </returns>
    public EFI_STATUS Invoke(nuint NumberOfEvents, EFI_EVENT Event, nuint Index)
        => FunctionPointer(NumberOfEvents, Event, Index);
}
