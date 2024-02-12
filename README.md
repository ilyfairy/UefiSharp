# CSharpEFI

## Build  

```C#
[RuntimeExport(nameof(EfiMain))]
public static long EfiMain(IntPtr imageHandle, EFI_SYSTEM_TABLE* systemTable)
{
    RuntimeInitializer.Initialize(imageHandle, systemTable);

    Console.WriteLine("HelloWorld!");
    while (true)
    {
        var c = Console.ReadKey();

        if(c == '\r')
        {
            Console.WriteLine();
        }
        else
        {
            Console.Write(c);
        }
    }
}
```

Ctrl+B 会在输出目录下生成 BOOTX64.EFI, 然后将其放入EFI/BOOT

![image1](./image1.png)