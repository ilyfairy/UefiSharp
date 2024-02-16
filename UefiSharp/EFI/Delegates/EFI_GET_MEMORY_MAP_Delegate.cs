using EFI.BootServices;

namespace EFI.Delegates;

/// <summary>
/// Returns the current memory map.
/// </summary>
public unsafe readonly struct EFI_GET_MEMORY_MAP_Delegate(delegate* unmanaged<nuint*, EFI_MEMORY_DESCRIPTOR*, nuint*, nuint*, uint, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<nuint*, EFI_MEMORY_DESCRIPTOR*, nuint*, nuint*, uint, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Returns the current memory map.
    /// </summary>
    /// <param name="MemoryMapSize">A pointer to the size, in bytes, of the MemoryMap buffer. On input, this is the size of the buffer allocated by the caller. On output, it is the size of the buffer returned by the firmware if the buffer was large enough, or the size of the buffer needed to contain the map if the buffer was too small.</param>
    /// <param name="MemoryMap">A pointer to the buffer in which firmware places the current memory map.</param>
    /// <param name="MapKey">A pointer to the location in which firmware returns the key for the current memory map.</param>
    /// <param name="DescriptorSize">A pointer to the location in which firmware returns the size, in bytes, of an individual EFI_MEMORY_DESCRIPTOR.</param>
    /// <param name="DescriptorVersion">A pointer to the location in which firmware returns the version number associated with the EFI_MEMORY_DESCRIPTOR.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The memory map was returned in the MemoryMap buffer.<br/>
    /// <see cref="EFI_STATUS.EFI_BUFFER_TOO_SMALL"/> The MemoryMap buffer was too small. The current buffer size needed to hold the memory map is returned in MemoryMapSize.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/><br/>
    /// 1) MemoryMapSize is NULL.<br/>
    /// 2) The MemoryMap buffer is not too small and MemoryMap is NULL.
    /// </returns>
    public EFI_STATUS Invoke(nuint* MemoryMapSize, EFI_MEMORY_DESCRIPTOR* MemoryMap, nuint* MapKey, nuint* DescriptorSize, uint DescriptorVersion) => FunctionPointer(MemoryMapSize, MemoryMap, MapKey, DescriptorSize, DescriptorVersion);
}
