using System;
using EFI.Times;

namespace EFI.RuntimeServices;

public unsafe readonly struct EFI_RUNTIME_SERVICES
{
    public readonly EFI_TABLE_HEADER Hdr;

    // Time Services
    public readonly delegate* unmanaged<EFI_TIME*, EFI_TIME_CAPABILITIES*, IntPtr> GetTime;
    public readonly delegate* unmanaged<EFI_TIME, IntPtr> SetTime;
    public readonly delegate* unmanaged<bool*, bool*, EFI_TIME*, IntPtr> GetWakeupTime;
    public readonly delegate* unmanaged<bool, in EFI_TIME, IntPtr> SetWakeupTime;

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

public unsafe struct EfiSetTimeDelegate
{
    public delegate* unmanaged<EFI_TIME*, EFI_TIME_CAPABILITIES*, IntPtr> Ptr;
}