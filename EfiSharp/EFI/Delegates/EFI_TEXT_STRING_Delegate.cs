namespace EFI.Delegates;

/// <summary>
/// Write a string to the output device.
/// </summary>
public unsafe readonly struct EFI_TEXT_STRING_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, char*, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, char*, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Write a string to the output device.
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <param name="String">The NULL-terminated string to be displayed on the output device(s). All output devices must also support the Unicode drawing character codes defined in this file.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The string was output to the device.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The device reported an error while attempting to output the text. <br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> The output device's mode is not currently in a defined text mode.<br/>
    /// <see cref="EFI_STATUS.EFI_WARN_UNKNOWN_GLYPH"/> This warning code indicates that some of the characters in the string could not be rendered and were skipped.<br/>
    /// </returns>
    public readonly EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This, char* String)
    {
        return FunctionPointer(This, String);
    }
}