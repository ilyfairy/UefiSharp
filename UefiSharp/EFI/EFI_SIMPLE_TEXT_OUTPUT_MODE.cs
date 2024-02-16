using System.Runtime.InteropServices;

namespace EFI;

[StructLayout(LayoutKind.Sequential)]
public struct EFI_SIMPLE_TEXT_OUTPUT_MODE
{
    /// <summary>
    /// The number of modes supported by QueryMode () and SetMode ().
    /// </summary>
    public int MaxMode;

    // current settings

    /// <summary>
    /// The text mode of the output device(s).
    /// </summary>
    public int Mode;

    /// <summary>
    /// The current character output attribute.
    /// </summary>
    public int Attribute;

    /// <summary>
    /// The cursor's column.
    /// </summary>
    public int CursorColumn;

    /// <summary>
    /// The cursor's row.
    /// </summary>
    public int CursorRow;

    /// <summary>
    /// The cursor is currently visbile or not.
    /// </summary>
    public bool CursorVisible;
}

