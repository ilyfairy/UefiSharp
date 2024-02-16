namespace EFI.Delegates;

/// <summary>
/// Makes the cursor visible or invisible
/// </summary>
public unsafe readonly struct EFI_TEXT_ENABLE_CURSOR_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, bool, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, bool, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Makes the cursor visible or invisible
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <param name="Visible">If TRUE, the cursor is set to be visible. If FALSE, the cursor is set to be invisible.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The operation completed successfully.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The device had an error and could not complete the request, or the device does not support changing the cursor mode.<br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> The output device is not in a valid text mode.
    /// </returns>
    public EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This, bool Visible)
        => FunctionPointer(This, Visible);
}

