using EFI.BootServices;

namespace EFI.Delegates;

/// <summary>
/// Allocates memory pages from the system.
/// </summary>
public unsafe readonly struct EFI_ALLOCATE_PAGES_Delegate(delegate* unmanaged<EFI_ALLOCATE_TYPE, EFI_MEMORY_TYPE, nuint, nuint*, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_ALLOCATE_TYPE, EFI_MEMORY_TYPE, nuint, nuint*, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Allocates memory pages from the system.
    /// </summary>
    /// <param name="Type">The type of allocation to perform.</param>
    /// <param name="MemoryType">The type of memory to allocate. MemoryType values in the range 0x70000000..0x7FFFFFFF are reserved for OEM use.MemoryType values in the range 0x80000000..0xFFFFFFFF are reserved for use by UEFI OS loaders that are provided by operating system vendors.</param>
    /// <param name="Pages">The number of contiguous 4 KB pages to allocate.</param>
    /// <param name="Memory">The pointer to a physical address. On input, the way in which the address is used depends on the value of Type.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The requested pages were allocated.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/><br/>
    /// 1) Type is not AllocateAnyPages or AllocateMaxAddress or AllocateAddress.<br/>
    /// 2) MemoryType is in the range EfiMaxMemoryType..0x6FFFFFFF.<br/>
    /// 3) Memory is NULL.<br/>
    /// 4) MemoryType is EfiPersistentMemory.<br/>
    /// <br/>
    /// <see cref="EFI_STATUS.EFI_OUT_OF_RESOURCES"/> The pages could not be allocated.<br/>
    /// <see cref="EFI_STATUS.EFI_NOT_FOUND"/> The requested pages could not be found.<br/>
    /// </returns>
    public EFI_STATUS Invoke(EFI_ALLOCATE_TYPE Type, EFI_MEMORY_TYPE MemoryType, nuint Pages, nuint* Memory) => FunctionPointer(Type, MemoryType, Pages, Memory);
}
