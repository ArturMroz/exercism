using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n <= 0 || n > 64) throw new ArgumentOutOfRangeException();

        return 1UL << n - 1;
    }

    public static ulong Total()
    {
        return Enumerable
           .Range(1, 64)
           .Select(Square)
           // couldn't use .Sum() here as it's not supported for ulong
           .Aggregate(0UL, (a, c) => a + c);
    }
}