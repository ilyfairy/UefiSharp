namespace EFI.Delegates;

/// <summary>
/// Clears the output device(s) display to the currently selected background color.
/// </summary>
public unsafe readonly struct EFI_TEXT_CLEAR_SCREEN_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Clears the output device(s) display to the currently selected background color.
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The operation completed successfully.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The device had an error and could not complete the request.<br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> The output device is not in a valid text mode.
    /// </returns>
    public EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This)
        => FunctionPointer(This);
}

