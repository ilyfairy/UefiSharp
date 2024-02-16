using EFI.Times;

namespace EFI.Delegates;

/// <summary>
/// Returns the current time and date information, and the time-keeping capabilities of the hardware platform.
/// </summary>
public unsafe readonly struct EFI_GET_TIME_Delegate(delegate* unmanaged<EFI_TIME*, EFI_TIME_CAPABILITIES*, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_TIME*, EFI_TIME_CAPABILITIES*, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Returns the current time and date information, and the time-keeping capabilities of the hardware platform.
    /// </summary>
    /// <param name="Time">A pointer to storage to receive a snapshot of the current time.</param>
    /// <param name="Capabilities">An optional pointer to a buffer to receive the real time clock device's capabilities.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The operation completed successfully.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/> Time is NULL.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The time could not be retrieved due to hardware error.<br/>
    /// </returns>
    public EFI_STATUS Invoke(EFI_TIME* Time, EFI_TIME_CAPABILITIES* Capabilities) => FunctionPointer(Time, Capabilities);
}
