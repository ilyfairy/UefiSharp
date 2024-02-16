using System.Runtime.InteropServices;

namespace EFI.BootServices;

/// <summary>
/// Creates an event.
/// </summary>
public unsafe readonly struct EFI_CREATE_EVENT_Delegate(delegate* unmanaged<EfiEventType, EFI_TPL, EFI_EVENT_NOTIFY, void*, EFI_EVENT*, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EfiEventType, EFI_TPL, EFI_EVENT_NOTIFY, void*, EFI_EVENT*, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Creates an event.
    /// </summary>
    /// <param name="Type">The type of event to create and its mode and attributes.</param>
    /// <param name="NotifyTpl">The task priority level of event notifications, if needed.</param>
    /// <param name="NotifyFunction">The pointer to the event's notification function, if any.</param>
    /// <param name="NotifyContext">The pointer to the notification function's context; corresponds to parameter　Context in the notification function.</param>
    /// <param name="Event">The pointer to the newly created event if the call succeeds; undefined otherwise.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The event structure was created.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/> One or more parameters are invalid.<br/>
    /// <see cref="EFI_STATUS.EFI_OUT_OF_RESOURCES"/> The event could not be allocated.
    /// </returns>
    public EFI_STATUS Invoke(EfiEventType Type, EFI_TPL NotifyTpl, EFI_EVENT_NOTIFY NotifyFunction, void* NotifyContext, [Out] EFI_EVENT* Event)
        => FunctionPointer(Type, NotifyTpl, NotifyFunction, NotifyContext, Event);
}

/// <summary>
/// These types can be ORed together as needed - for example,
/// EVT_TIMER might be Ored with EVT_NOTIFY_WAIT or
/// EVT_NOTIFY_SIGNAL.
/// </summary>
public enum EfiEventType : uint
{
    EVT_TIMER = 0x80000000,
    EVT_RUNTIME = 0x40000000,
    EVT_NOTIFY_WAIT = 0x00000100,
    EVT_NOTIFY_SIGNAL = 0x00000200,

    EVT_SIGNAL_EXIT_BOOT_SERVICES = 0x00000201,
    EVT_SIGNAL_VIRTUAL_ADDRESS_CHANGE = 0x60000202,
}