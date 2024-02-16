using System.Runtime.CompilerServices;

namespace EFI.Delegates;

public readonly unsafe struct EFI_TEXT_RESET_Delegate(delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, bool, EFI_STATUS> fp)
{
    public readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, bool, EFI_STATUS> FunctionPointer = fp;

    /// <summary>
    /// The protocol instance pointer.
    /// </summary>
    /// <param name="This">The protocol instance pointer.</param>
    /// <param name="ExtendedVerification">Driver may perform more exhaustive verification operation of the device during reset.</param>
    /// <returns></returns>
    public readonly EFI_STATUS Invoke(EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* This, bool ExtendedVerification)
        => FunctionPointer(This, ExtendedVerification);
}
