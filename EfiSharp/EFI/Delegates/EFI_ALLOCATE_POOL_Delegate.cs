using EFI.BootServices;

namespace EFI.Delegates;

/// <summary>
/// Allocates pool memory.
/// </summary>
public unsafe readonly struct EFI_ALLOCATE_POOL_Delegate(delegate* unmanaged<EFI_MEMORY_TYPE, nuint, void**, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_MEMORY_TYPE, nuint, void**, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// Allocates pool memory.
    /// </summary>
    /// <param name="PoolType">The type of pool to allocate. MemoryType values in the range 0x70000000..0x7FFFFFFF are reserved for OEM use.MemoryType values in the range 0x80000000..0xFFFFFFFF are reserved for use by UEFI OS loaders that are provided by operating system vendors.</param>
    /// <param name="Size">The number of bytes to allocate from the pool.</param>
    /// <param name="Buffer">A pointer to a pointer to the allocated buffer if the call succeeds; undefined otherwise.</param>
    /// <returns>
    /// <see cref="EFI_STATUS.EFI_SUCCESS"/> The requested number of bytes was allocated.<br/>
    /// <see cref="EFI_STATUS.EFI_OUT_OF_RESOURCES"/> The pool requested could not be allocated.<br/>
    /// <see cref="EFI_STATUS.EFI_INVALID_PARAMETER"/> Buffer is NULL. PoolType is in the range EfiMaxMemoryType..0x6FFFFFFF. PoolType is EfiPersistentMemory.
    /// </returns>
    public EFI_STATUS Invoke(EFI_MEMORY_TYPE PoolType, nuint Size, void** Buffer) => FunctionPointer(PoolType, Size, Buffer);
}
