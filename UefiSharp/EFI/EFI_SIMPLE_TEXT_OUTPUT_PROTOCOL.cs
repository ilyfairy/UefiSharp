using System.Runtime.InteropServices;
using EFI.Delegates;

namespace EFI;

/// <summary>
/// The SIMPLE_TEXT_OUTPUT protocol is used to control text-based output devices.
/// It is the minimum required protocol for any handle supplied as the ConsoleOut
/// or StandardError device. In addition, the minimum supported text mode of such
/// devices is at least 80 x 25 characters.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL
{
    /// <summary>
    /// Reset the text output device hardware and optionaly run diagnostics
    /// </summary>
    public readonly EFI_TEXT_RESET_Delegate Reset;

    /// <summary>
    /// Write a string to the output device.
    /// </summary>
    public readonly EFI_TEXT_STRING_Delegate OutputString;
    /// <summary>
    /// Verifies that all characters in a string can be output to the target device.
    /// </summary>
    public readonly EFI_TEXT_TEST_STRING_Delegate TestString;

    /// <summary>
    /// Returns information for an available text mode that the output device(s) supports.
    /// </summary>
    public readonly EFI_TEXT_QUERY_MODE_Delegate QueryMode;

    /// <summary>
    /// Sets the output device(s) to a specified mode.
    /// </summary>
    public readonly EFI_TEXT_SET_MODE_Delegate SetMode;

    /// <summary>
    /// Clears the output device(s) display to the currently selected background color.
    /// </summary>
    public readonly EFI_TEXT_SET_ATTRIBUTE_Delegate SetAttribute;

    /// <summary>
    /// Sets the background and foreground colors for the OutputString () and ClearScreen() functions.
    /// </summary>
    public readonly EFI_TEXT_CLEAR_SCREEN_Delegate ClearScreen;

    /// <summary>
    /// Sets the current coordinates of the cursor position
    /// </summary>
    public readonly EFI_TEXT_SET_CURSOR_POSITION_Delegate SetCursorPosition;

    /// <summary>
    /// Makes the cursor visible or invisible
    /// </summary>
    public readonly EFI_TEXT_ENABLE_CURSOR_Delegate EnableCursor;

    /// <summary>
    /// Pointer to SIMPLE_TEXT_OUTPUT_MODE data.
    /// </summary>
    public readonly EFI_SIMPLE_TEXT_OUTPUT_MODE* Mode;

}
