using System;
using System.Runtime.InteropServices;

namespace EFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SIMPLE_TEXT_INPUT_PROTOCOL
{
    public ulong _buf;

    public delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_PROTOCOL*, EFI_INPUT_KEY*, ulong> ReadKeyStroke;
    public void* WaitForKey;
};

//struct EFI_SIMPLE_TEXT_INPUT_PROTOCOL
//{
//    unsigned long long _buf;
//    unsigned long long (* ReadKeyStroke) (
//        struct EFI_SIMPLE_TEXT_INPUT_PROTOCOL *This,
//        struct EFI_INPUT_KEY *Key);
//};