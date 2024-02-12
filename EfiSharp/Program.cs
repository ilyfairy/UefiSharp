using System;
using System.Runtime;
using EFI;

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
}
