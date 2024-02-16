namespace EFI.BootServices;

public readonly unsafe struct EFI_EVENT_NOTIFY(delegate* unmanaged<EFI_EVENT, void*, void> fp)
{
    public readonly delegate* unmanaged<EFI_EVENT, void*, void> FunctionPointer = fp;

    public readonly void Invoke(EFI_EVENT Event, void* Context) => FunctionPointer(Event, Context);

    public static implicit operator EFI_EVENT_NOTIFY(delegate* unmanaged<EFI_EVENT, void*, void> fp) => new(fp);
    public static implicit operator EFI_EVENT_NOTIFY(void* fp) => new((delegate* unmanaged<EFI_EVENT, void*, void>)fp);
}
