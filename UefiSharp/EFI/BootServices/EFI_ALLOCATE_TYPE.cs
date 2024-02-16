namespace EFI.BootServices;

public enum EFI_ALLOCATE_TYPE
{
    /// <summary>
    /// Allocate any available range of pages that satisfies the request.
    /// </summary>
    AllocateAnyPages,

    ///<summary>
    /// Allocate any available range of pages whose uppermost address is less than
    /// or equal to a specified maximum address.
    /// </summary>
    AllocateMaxAddress,

    /// <summary>
    /// Allocate pages at a specified address.
    /// </summary>
    AllocateAddress,

    /// <summary>
    /// Maximum enumeration value that may be used for bounds checking.
    /// </summary>
    MaxAllocateType
}
