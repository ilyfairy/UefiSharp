using System;

namespace EFI;

public struct EFI_INPUT_KEY
{
    public ushort ScanCode;
    public char UnicodeChar;
};