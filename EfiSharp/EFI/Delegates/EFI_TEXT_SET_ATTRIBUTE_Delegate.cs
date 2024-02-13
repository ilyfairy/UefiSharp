namespace EFI.Delegates;

/// <summary>
/// Sets the background and foreground colors for the OutputString () and ClearScreen() functions.
/// </summary>
public unsafe readonly struct EFI_TEXT_SET_ATTRIBUTE_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, nuint, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, nuint, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Sets the background and foreground colors for the OutputString () and ClearScreen() functions.
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <param name="Attribute">The attribute to set. Bits 0..3 are the foreground color, and bits 4..6 are the background color.All other bits are undefined and must be zero. The valid Attributes are defined in this file.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The attribute was set.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The device had an error and could not complete the request.<br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> The attribute requested is not defined.
    /// </returns>
    public EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This, nuint Attribute)
        => FunctionPointer(This, Attribute);
}
