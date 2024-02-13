using System;
using System.Runtime.InteropServices;
using EFI.Delegates;

namespace EFI.BootServices;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BOOT_SERVICES
{
    /// <summary>
    /// The table header for the EFI Boot Services Table.
    /// </summary>
    public EFI_TABLE_HEADER Hdr; // 24 bytes

    // Task Priority Services  16 bytes
    public EFI_RAISE_TPL_Delegate RaiseTPL;
    public EFI_RESTORE_TPL_Delegate RestoreTPL;

    // Memory Services   40 bytes
    public EFI_ALLOCATE_PAGES_Delegate AllocatePages;
    public EFI_FREE_PAGES_Delegate FreePages;
    public EFI_GET_MEMORY_MAP_Delegate GetMemoryMap;
    public EFI_ALLOCATE_POOL_Delegate AllocatePool;
    public delegate* unmanaged<UIntPtr, UIntPtr> FreePool;

    //// Event & Timer Services
    //EFI_CREATE_EVENT CreateEvent;
    //EFI_SET_TIMER SetTimer;
    //EFI_WAIT_FOR_EVENT WaitForEvent;
    //EFI_SIGNAL_EVENT SignalEvent;
    //EFI_CLOSE_EVENT CloseEvent;
    //EFI_CHECK_EVENT CheckEvent;

    //// Protocol Handler Services
    //EFI_INSTALL_PROTOCOL_INTERFACE InstallProtocolInterface;
    //EFI_REINSTALL_PROTOCOL_INTERFACE ReinstallProtocolInterface;
    //EFI_UNINSTALL_PROTOCOL_INTERFACE UninstallProtocolInterface;
    //EFI_HANDLE_PROTOCOL HandleProtocol;
    //VOID* Reserved;
    //EFI_REGISTER_PROTOCOL_NOTIFY RegisterProtocolNotify;
    //EFI_LOCATE_HANDLE LocateHandle;
    //EFI_LOCATE_DEVICE_PATH LocateDevicePath;
    //EFI_INSTALL_CONFIGURATION_TABLE InstallConfigurationTable;

    //// Image Services
    //EFI_IMAGE_LOAD LoadImage;
    //EFI_IMAGE_START StartImage;
    //EFI_EXIT Exit;
    //EFI_IMAGE_UNLOAD UnloadImage;
    //EFI_EXIT_BOOT_SERVICES ExitBootServices;

    //// Miscellaneous Services
    //EFI_GET_NEXT_MONOTONIC_COUNT GetNextMonotonicCount;
    //EFI_STALL Stall;
    //EFI_SET_WATCHDOG_TIMER SetWatchdogTimer;

    //// DriverSupport Services
    //EFI_CONNECT_CONTROLLER ConnectController;
    //EFI_DISCONNECT_CONTROLLER DisconnectController;

    //// Open and Close Protocol Services
    //EFI_OPEN_PROTOCOL OpenProtocol;
    //EFI_CLOSE_PROTOCOL CloseProtocol;
    //EFI_OPEN_PROTOCOL_INFORMATION OpenProtocolInformation;

    //// Library Services
    //EFI_PROTOCOLS_PER_HANDLE ProtocolsPerHandle;
    //EFI_LOCATE_HANDLE_BUFFER LocateHandleBuffer;
    //EFI_LOCATE_PROTOCOL LocateProtocol;
    //EFI_INSTALL_MULTIPLE_PROTOCOL_INTERFACES InstallMultipleProtocolInterfaces;
    //EFI_UNINSTALL_MULTIPLE_PROTOCOL_INTERFACES UninstallMultipleProtocolInterfaces;

    //// 32-bit CRC Services
    //EFI_CALCULATE_CRC32 CalculateCrc32;

    //// Miscellaneous Services
    //EFI_COPY_MEM CopyMem;
    //EFI_SET_MEM SetMem;
    //EFI_CREATE_EVENT_EX CreateEventEx;
}
