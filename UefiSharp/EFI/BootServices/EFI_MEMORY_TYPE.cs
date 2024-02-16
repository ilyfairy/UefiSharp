namespace EFI.BootServices;

/// <summary>
/// Enumeration of memory types introduced in UEFI.
/// </summary>
public enum EFI_MEMORY_TYPE
{
    /// <summary>
    /// Not used.
    /// </summary>
    EfiReservedMemoryType,

    /// <summary>
    /// The code portions of a loaded application.
    /// (Note that UEFI OS loaders are UEFI applications.)
    /// </summary>
    EfiLoaderCode,

    /// <summary>
    /// The data portions of a loaded application and the default data allocation
    /// type used by an application to allocate pool memory.
    /// </summary>
    EfiLoaderData,

    /// <summary>
    /// The code portions of a loaded Boot Services Driver.
    /// </summary>
    EfiBootServicesCode,

    /// <summary>
    /// The data portions of a loaded Boot Serves Driver, and the default data
    /// allocation type used by a Boot Services Driver to allocate pool memory.
    /// </summary>
    EfiBootServicesData,

    /// <summary>
    /// The code portions of a loaded Runtime Services Driver.
    /// </summary>
    EfiRuntimeServicesCode,

    /// <summary>
    /// The data portions of a loaded Runtime Services Driver and the default
    /// data allocation type used by a Runtime Services Driver to allocate pool memory.
    /// </summary>
    EfiRuntimeServicesData,

    /// <summary>
    /// Free (unallocated) memory.
    /// </summary>
    EfiConventionalMemory,

    /// <summary>
    /// Memory in which errors have been detected.
    /// </summary>
    EfiUnusableMemory,

    /// <summary>
    /// Memory that holds the ACPI tables.
    /// </summary>
    EfiACPIReclaimMemory,

    /// <summary>
    /// Address space reserved for use by the firmware.
    /// </summary>
    EfiACPIMemoryNVS,

    /// <summary>
    /// Used by system firmware to request that a memory-mapped IO region
    /// be mapped by the OS to a virtual address so it can be accessed by EFI runtime services.
    /// </summary>
    EfiMemoryMappedIO,

    /// <summary>
    /// System memory-mapped IO region that is used to translate memory
    /// cycles to IO cycles by the processor.
    /// </summary>
    EfiMemoryMappedIOPortSpace,

    /// <summary>
    /// Address space reserved by the firmware for code that is part of the processor.
    /// </summary>
    EfiPalCode,

    /// <summary>
    /// A memory region that operates as EfiConventionalMemory,
    /// however it happens to also support byte-addressable non-volatility.
    /// </summary>
    EfiPersistentMemory,

    EfiMaxMemoryType
}