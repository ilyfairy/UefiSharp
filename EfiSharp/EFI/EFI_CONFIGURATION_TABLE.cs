using System;

namespace EFI;

public unsafe struct EFI_CONFIGURATION_TABLE
{
    ///
    /// The 128-bit GUID value that uniquely identifies the system configuration table.
    ///
    public Guid VendorGuid;
    //public EFI_GUID VendorGuid;

    ///
    /// A pointer to the table associated with VendorGuid.
    ///
    public void* VendorTable;
}
