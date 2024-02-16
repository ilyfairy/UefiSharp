namespace System;

public static class Math
{
    public static (uint Quotient, uint Remainder) DivRem(uint left, uint right)
    {
        uint quotient = left / right;
        return (quotient, left - (quotient * right));
    }

    public static long BigMul(int a, int b)
        => ((long)a) * b;
}
