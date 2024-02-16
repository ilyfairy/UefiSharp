namespace EFI.BootServices;

/// <summary>
/// Sets the type of timer and the trigger time for a timer event.
/// </summary>
public unsafe readonly struct EFI_SET_TIMER_Delegate(delegate* unmanaged<EFI_EVENT, EFI_TIMER_DELAY, ulong, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_EVENT, EFI_TIMER_DELAY, ulong, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Sets the type of timer and the trigger time for a timer event.
    /// </summary>
    /// <param name="Event">The timer event that is to be signaled at the specified time.</param>
    /// <param name="Type">The type of time that is specified in TriggerTime.</param>
    /// <param name="TriggerTime">
    /// The number of 100ns units until the timer expires.<br/>
    /// A TriggerTime of 0 is legal.<br/>
    /// If Type is TimerRelative and TriggerTime is 0, then the timer event will be signaled on the next timer tick.<br/>
    /// If Type is TimerPeriodic and TriggerTime is 0, then the timer event will be signaled on every timer tick.
    /// </param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The event has been set to be signaled at the requested time.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/> Event or Type is not valid.<br/>
    /// </returns>
    public EFI_STATUS Invoke(EFI_EVENT Event, EFI_TIMER_DELAY Type, ulong TriggerTime)
        => FunctionPointer(Event, Type, TriggerTime);
}
