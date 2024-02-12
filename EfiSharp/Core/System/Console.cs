using EFI;

namespace System;

public static unsafe class Console
{
    private static EFI_SYSTEM_TABLE* systemTable;

    public static void Initialize(EFI_SYSTEM_TABLE* systemTable)
    {
        Console.systemTable = systemTable;
    }

    public static void Write(char c)
    {
        (char, char) chars = (c, '\0');
        systemTable->ConOut->OutputString(systemTable->ConOut, (char*)&chars);
    }

    public static void Write(int num)
    {
        if(num == 0)
        {
            Write('0');
            return;
        }
        if (num == int.MinValue)
        {
            Write("-2147483648");
            return;
        }

        if (num < 0)
        {
            Write('-');
            num = -num;
        }

        // 计算数字位数
        int numDigits = 0;
        int temp = num;
        while (temp != 0)
        {
            temp /= 10;
            numDigits++;
        }

        // 打印每一位数字
        for (int i = 0; i < numDigits; i++)
        {
            // 计算当前位数字
            int divisor = 1;
            for (int j = 1; j < numDigits - i; j++)
            {
                divisor *= 10;
            }
            int digit = num / divisor;

            // 打印当前位数字字符
            Write((char)('0' + digit));

            // 更新num，去掉已经打印的最高位数字
            num -= digit * divisor;
        }
    }

    public static void Write(char* chars)
    {
        systemTable->ConOut->OutputString(systemTable->ConOut, chars);
    }

    public static void Write(string chars)
    {
        fixed (char* ptr = chars)
            Write(ptr);
    }

    public static void WriteLine() => Write("\r\n");
    public static void WriteLine(int num)
    {
        Write(num);
        Write("\r\n");
    }
    public static void WriteLine(char* chars)
    {
        systemTable->ConOut->OutputString(systemTable->ConOut, chars);
        Write("\r\n");
    }

    public static void WriteLine(string chars)
    {
        Write(chars);
        Write("\r\n");
    }

    public static EFI_INPUT_KEY InternalReadKey()
    {
        EFI_INPUT_KEY key;
        systemTable->ConIn->ReadKeyStroke(systemTable->ConIn, &key);
        return key;
    }

    public static char ReadKey()
    {
        while (true)
        {
            var key = InternalReadKey();
            if (key.UnicodeChar != '\0')
                return key.UnicodeChar;
        }
    }

    public static void ReadLine(char* output, int maxLength, bool isShow)
    {
        int index = 0;
        while (true)
        {
            char c = ReadKey();

            if (c == '\r')
            {
                if (isShow)
                    WriteLine();
                return;
            }    

            if (isShow)
                Write(c);

            output[index++] = c;
            if(index >= maxLength)
                return;
        }
    }

    public static void Clear()
    {
        systemTable->ConOut->ClearScreen(systemTable->ConOut);
    }
}