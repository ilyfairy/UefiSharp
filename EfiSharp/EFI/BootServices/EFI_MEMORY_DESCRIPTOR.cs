using System.Runtime.InteropServices;

namespace EFI.BootServices;

/// <summary>
/// Definition of an EFI memory descriptor.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct EFI_MEMORY_DESCRIPTOR
{
    /// <summary>
    /// Type of the memory region.
    /// Type EFI_MEMORY_TYPE is defined in the
    /// AllocatePages() function description.
    /// </summary>
    public uint Type;

    /// <summary>
    /// Physical address of the first byte in the memory region. PhysicalStart must be
    /// aligned on a 4 KiB boundary, and must not be above 0xfffffffffffff000. Type
    /// EFI_PHYSICAL_ADDRESS is defined in the AllocatePages() function description
    /// </summary>
    public ulong PhysicalStart;

    /// <summary>
    /// Virtual address of the first byte in the memory region.
    /// VirtualStart must be aligned on a 4 KiB boundary,
    /// and must not be above 0xfffffffffffff000.
    /// </summary>
    public ulong VirtualStart;

    /// <summary>
    /// NumberOfPagesNumber of 4 KiB pages in the memory region.
    /// NumberOfPages must not be 0, and must not be any value
    /// that would represent a memory page with a start address,
    /// either physical or virtual, above 0xfffffffffffff000.
    /// </summary>
    public ulong NumberOfPages;

    /// <summary>
    /// Attributes of the memory region that describe the bit mask of capabilities
    /// for that memory region, and not necessarily the current settings for that
    /// memory region.
    /// </summary>
    public ulong Attribute;
}