using System;
using System.Runtime.InteropServices;
using EFI.Delegates;
using EFI.Times;

namespace EFI.RuntimeServices;

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct EFI_RUNTIME_SERVICES
{
    public readonly EFI_TABLE_HEADER Hdr;

    // Time Services
    public readonly EFI_GET_TIME_Delegate GetTime;
    public readonly EFI_SET_TIME_Delegate SetTime;
    public readonly delegate* unmanaged<bool*, bool*, EFI_TIME*, UIntPtr> GetWakeupTime;
    public readonly delegate* unmanaged<bool, in EFI_TIME, UIntPtr> SetWakeupTime;

    //// Virtual Memory Services
    //public readonly EFI_SET_VIRTUAL_ADDRESS_MAP SetVirtualAddressMap;
    //public readonly EFI_CONVERT_POINTER ConvertPointer;

    //// Variable Services
    //public readonly EFI_GET_VARIABLE GetVariable;
    //public readonly EFI_GET_NEXT_VARIABLE_NAME GetNextVariableName;
    //public readonly EFI_SET_VARIABLE SetVariable;

    //// Miscellaneous Services
    //public readonly EFI_GET_NEXT_HIGH_MONO_COUNT GetNextHighMonotonicCount;
    //public readonly EFI_RESET_SYSTEM ResetSystem;

    //// UEFI 2.0 Capsule Services
    //public readonly EFI_UPDATE_CAPSULE UpdateCapsule;
    //public readonly EFI_QUERY_CAPSULE_CAPABILITIES QueryCapsuleCapabilities;

    //// Miscellaneous UEFI 2.0 Service
    //public readonly EFI_QUERY_VARIABLE_INFO QueryVariableInfo;
}
