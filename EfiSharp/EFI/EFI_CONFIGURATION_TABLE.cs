using System;

namespace EFI;

public unsafe struct EFI_CONFIGURATION_TABLE
{
    /// <summary>
    /// The 128-bit GUID value that uniquely identifies the system configuration table.
    /// </summary>
    public Guid VendorGuid; //public EFI_GUID VendorGuid;

    /// <summary>
    /// A pointer to the table associated with VendorGuid.
    /// </summary>
    public void* VendorTable;
}
