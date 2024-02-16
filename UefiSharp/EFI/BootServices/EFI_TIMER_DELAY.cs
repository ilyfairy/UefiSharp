namespace EFI.BootServices;

/// <summary>
/// Timer delay types
/// </summary>
public enum EFI_TIMER_DELAY
{
    /// <summary>
    /// An event's timer settings is to be cancelled and not trigger time is to be set/
    /// </summary>
    TimerCancel,
    /// <summary>
    /// An event is to be signaled periodically at a specified interval from the current time.
    /// </summary>
    TimerPeriodic,
    /// <summary>
    /// An event is to be signaled once at a specified interval from the current time.
    /// </summary>
    TimerRelative
}
