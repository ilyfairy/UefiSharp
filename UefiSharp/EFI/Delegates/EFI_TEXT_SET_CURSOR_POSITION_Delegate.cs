namespace EFI.Delegates;

/// <summary>
/// Sets the current coordinates of the cursor position
/// </summary>
public unsafe readonly struct EFI_TEXT_SET_CURSOR_POSITION_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, nuint, nuint, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, nuint, nuint, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Sets the current coordinates of the cursor position
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <param name="Column">The position to set the cursor to. Must be greater than or equal to zero and less than the number of columns and rows by QueryMode().</param>
    /// <param name="Row">The position to set the cursor to. Must be greater than or equal to zero and less than the number of columns and rows by QueryMode().</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The operation completed successfully.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The device had an error and could not complete the request.<br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> The output device is not in a valid text mode, or the cursor position is invalid for the current mode.
    /// </returns>
    public EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This, nuint Column, nuint Row)
        => FunctionPointer(This, Column, Row);
}
