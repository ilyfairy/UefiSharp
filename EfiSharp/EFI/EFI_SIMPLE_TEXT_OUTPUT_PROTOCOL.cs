using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL
{
    private readonly IntPtr _pad;

    public readonly delegate* unmanaged<void*, char*, void*> OutputString;
    public readonly Array4<ulong> _buf2;
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, void> ClearScreen;

    [InlineArray(4)]
    public struct Array4<T> { public T first; }
}

//struct EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL
//{
//    unsigned long long _buf;
//    unsigned long long (* OutputString) (
//        struct EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL *This,
//        unsigned short* String);
//    unsigned long long _buf2[4];
//    unsigned long long (* ClearScreen) (
//        struct EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL *This);
//}