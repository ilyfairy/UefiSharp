namespace EFI.Delegates;

/// <summary>
/// Sets the output device(s) to a specified mode.
/// </summary>
public unsafe readonly struct EFI_TEXT_SET_MODE_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, nuint, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, nuint, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Sets the output device(s) to a specified mode.
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <param name="ModeNumber">The mode number to set.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The requested text mode was set.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The device had an error and could not complete the request.<br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> The mode number was not valid.
    /// </returns>
    public EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This, nuint ModeNumber)
        => FunctionPointer(This, ModeNumber);
}
