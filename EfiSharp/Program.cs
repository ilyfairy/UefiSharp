using System;
using System.Runtime;
using Core.System.Runtime.InteropServices;
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

        Span<char> buffer = stackalloc char[1024];
        Console.WriteLine("HelloWorld!");

        while (true)
        {
            buffer.Clear();

            Console.Write(">>> ");
            Console.ReadLine(buffer, 1024, true);
            
            if (string.Equals(buffer, "hi"))
                Console.WriteLine("Hello!");
            else if (string.Equals(buffer, "exit"))
                Console.WriteLine("bye~");
            else
            {
                Console.Write("unknown input: ");
                Console.WriteLine(buffer);
            }
        }
    }
}
