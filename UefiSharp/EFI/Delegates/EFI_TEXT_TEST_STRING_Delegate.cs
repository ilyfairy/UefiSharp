namespace EFI.Delegates;

/// <summary>
/// Verifies that all characters in a string can be output to the target device.
/// </summary>
public unsafe readonly struct EFI_TEXT_TEST_STRING_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, char*, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, char*, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Verifies that all characters in a string can be output to the target device.
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <param name="String">The NULL-terminated string to be examined for the output device(s).</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The device(s) are capable of rendering the output string.<br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> Some of the characters in the string cannot be rendered by one or more of the output devices mapped by the EFI handle.
    /// </returns>
    public EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This, char* String)
        => FunctionPointer(This, String);
}