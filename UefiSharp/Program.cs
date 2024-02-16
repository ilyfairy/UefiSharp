using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using EFI;
using EFI.BootServices;
using Internal.Runtime;

public unsafe class Program
{
    /// <summary>
    /// 假的Main
    /// </summary>
    static void Main() { }

    /// <summary>
    /// 入口点
    /// </summary>
    /// <returns></returns>
    [RuntimeExport(nameof(EfiMain))]
    public static long EfiMain(IntPtr imageHandle, EFI_SYSTEM_TABLE* systemTable)
    {
        RuntimeInitializer.Initialize(imageHandle, systemTable);

        Span<char> buffer = stackalloc char[1024];
        Console.WriteLine("HelloWorld!");

        systemTable->ConOut->ClearScreen.Invoke(systemTable->ConOut);

        Console.WriteLine("HelloWorld!2");

        Console.Write("EFI_BOOT_SERVICES Size: ");
        Console.WriteLine(sizeof(EFI_BOOT_SERVICES));

        Console.Write("VendorGuid: ");
        Console.WriteLine(systemTable->ConfigurationTable.VendorGuid);

        Console.WriteLine(string.Empty.Length);
        Console.WriteLine(true);
        Console.WriteLine(false);

        Console.Write("Current DateTime: ");
        Console.WriteLine(DateTime.Now);

        foreach (var item in "abc1234")
        {
            Console.Write(item);
        }

        Console.WriteLine();

        while (true)
        {
            buffer.Clear();

            Console.Write(">>> ");
            Console.ReadLine(buffer, buffer.Length, true);
            
            if (string.Equals(buffer, "hi"))
                Console.WriteLine("Hello!");
            else if (string.Equals(buffer, "exit"))
                Console.WriteLine("bye~");
            else if (string.Equals(buffer, "on"))
                Console.CursorVisible = true;
            else if (string.Equals(buffer, "off"))
                Console.CursorVisible = false;
            else if(string.Equals(buffer, "time"))
            {
                Console.Write("Current DateTime: ");
                Console.WriteLine(DateTime.Now);
            }
            else
            {
                Console.Write("unknown input: ");
                Console.WriteLine(buffer);
            }


        }
    }
}

