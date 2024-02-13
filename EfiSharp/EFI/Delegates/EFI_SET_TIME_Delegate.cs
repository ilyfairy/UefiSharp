using EFI.Times;

namespace EFI.Delegates;

/// <summary>
/// Sets the current local time and date information.
/// </summary>
public unsafe readonly struct EFI_SET_TIME_Delegate(delegate* unmanaged<EFI_TIME*, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_TIME*, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Sets the current local time and date information.
    /// </summary>
    /// <param name="Time">A pointer to the current time.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The operation completed successfully.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/> A time field is out of range.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The time could not be set due due to hardware error.<br/>
    /// </returns>
    public EFI_STATUS Invoke(EFI_TIME* Time) => FunctionPointer(Time);
}
