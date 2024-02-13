namespace EFI.Delegates;

/// <summary>
/// Returns information for an available text mode that the output device(s) supports.
/// </summary>
public unsafe readonly struct EFI_TEXT_QUERY_MODE_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, nuint, out nuint, out nuint, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, nuint, out nuint, out nuint, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Returns information for an available text mode that the output device(s) supports.
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <param name="ModeNumber">The mode number to return information on.</param>
    /// <param name="Columns">Returns the geometry of the text output device for the requested ModeNumber.</param>
    /// <param name="Rows">Returns the geometry of the text output device for the requested ModeNumber.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The requested mode information was returned.<br/>
    /// <see cref="EFI_STATUS.EFI_DEVICE_ERROR"/> The device had an error and could not complete the request.<br/>
    /// <see cref="EFI_STATUS.EFI_UNSUPPORTED"/> The mode number was not valid.
    /// </returns>
    public EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This, nuint ModeNumber, out nuint Columns, out nuint Rows)
        => FunctionPointer(This, ModeNumber, out Columns, out Rows);
}
