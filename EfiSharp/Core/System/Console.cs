using System.Runtime.CompilerServices;
using EFI;

namespace System;

public static unsafe class Console
{
    private static EFI_SYSTEM_TABLE* systemTable;

    public static int CursorLeft
    {
        get => systemTable->ConOut->Mode->CursorColumn;
        set => systemTable->ConOut->Mode->CursorColumn = value;
    }

    public static int CursorTop
    {
        get => systemTable->ConOut->Mode->CursorRow;
        set => systemTable->ConOut->Mode->CursorRow = value;
    }

    public static bool CursorVisible
    {
        get => systemTable->ConOut->Mode->CursorVisible;
        set => systemTable->ConOut->EnableCursor.Invoke(systemTable->ConOut, value);
    }

    public static void Initialize(EFI_SYSTEM_TABLE* systemTable)
    {
        Console.systemTable = systemTable;
    }

    public static void Write(char c)
    {
        (char, char) chars = (c, '\0');
        systemTable->ConOut->OutputString.Invoke(systemTable->ConOut, (char*)&chars);
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

    public static void Write(nint num)
    {
        if (num == 0)
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
        nint temp = num;
        while (temp != 0)
        {
            temp /= 10;
            numDigits++;
        }

        // 打印每一位数字
        for (int i = 0; i < numDigits; i++)
        {
            // 计算当前位数字
            nint divisor = 1;
            for (int j = 1; j < numDigits - i; j++)
            {
                divisor *= 10;
            }
            nint digit = num / divisor;

            // 打印当前位数字字符
            Write((char)('0' + digit));

            // 更新num，去掉已经打印的最高位数字
            num -= digit * divisor;
        }
    }

    public static void Write(char* chars)
    {
        systemTable->ConOut->OutputString.Invoke(systemTable->ConOut, chars);
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
        systemTable->ConOut->OutputString.Invoke(systemTable->ConOut, chars);
        Write("\r\n");
    }

    public static void WriteLine(string chars)
    {
        Write(chars);
        Write("\r\n");
    }

    public static void WriteLine(bool value) => WriteLine(value.ToString());

    public static void WriteLine(nint num)
    {
        Write(num);
        Write("\r\n");
    }

    public static void Write(DateTime dateTime)
    {
        Write(dateTime.Year);
        Write('/');
        Write(dateTime.Month);
        Write('/');
        Write(dateTime.Day);

        Write(' ');

        if(dateTime.Hour < 10)
            Write('0');
        Write(dateTime.Hour);
        Write(':');
        if (dateTime.Minute < 10)
            Write('0');
        Write(dateTime.Minute);
        Write(':');
        if (dateTime.Second < 10)
            Write('0');
        Write(dateTime.Second);
    }
    public static void WriteLine(DateTime dateTime)
    {
        Write(dateTime);
        WriteLine();
    }

    public static void WriteLine(Guid guid)
    {
        Write(guid);
        WriteLine();
    }

    public static void Write(Guid guid)
    {
        var ptr = (byte*)&guid;

        for (int i = 0; i < 4; i++)
            WriteHex(*ptr++);

        Write('-');

        for (int i = 0; i < 2; i++)
            WriteHex(*ptr++);

        Write('-');

        for (int i = 0; i < 2; i++)
            WriteHex(*ptr++);

        Write('-');

        for (int i = 0; i < 2; i++)
            WriteHex(*ptr++);

        Write('-');

        for (int i = 0; i < 6; i++)
            WriteHex(*ptr++);

        static void WriteHex(byte hex)
        {
            var l = hex & 0xF;
            var h = (hex >> 4) & 0xF;

            Write((char)(l < 10 ? '0' + l : 'a' + l - 10));
            Write((char)(h < 10 ? '0' + h : 'a' + h - 10));
        }
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
        systemTable->ConOut->ClearScreen.Invoke(systemTable->ConOut);
    }


    public static void SetCursorPosition(int column, int row)
        => systemTable->ConOut->SetCursorPosition.Invoke(systemTable->ConOut, (uint)column, (uint)row);

    public static (int Left,int Top) GetCursorPosition()
        => (systemTable->ConOut->Mode->CursorColumn, systemTable->ConOut->Mode->CursorRow);
}