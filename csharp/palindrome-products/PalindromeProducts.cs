using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    private enum CompareMode { Min, Max }

    private static (int, IEnumerable<(int, int)>) GetExtremePalindrome(int minFactor, int maxFactor, CompareMode mode)
    {
        var extremeFactor = mode == CompareMode.Max ? int.MinValue : int.MaxValue;
        var curExtrema = (extremeFactor: extremeFactor, factors: new List<(int, int)>());
        var hasFoundPalindrome = false;
        int curProduct;

        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                curProduct = i * j;
                if (IsPalindrome(curProduct))
                {
                    hasFoundPalindrome = true;

                    if ((mode == CompareMode.Max && curProduct > curExtrema.extremeFactor) ||
                        (mode == CompareMode.Min && curProduct < curExtrema.extremeFactor))
                    {
                        curExtrema = (curProduct, new List<(int, int)> { (i, j) });
                    }
                    else if (curProduct == curExtrema.extremeFactor)
                    {
                        curExtrema.factors.Add((i, j));
                    }
                }
            }
        }

        if (hasFoundPalindrome)
        {
            return curExtrema;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public static bool IsPalindrome(int number)
    {
        var temp = number;
        var reversed = 0;
        int remaninder;

        while (temp > 0)
        {
            remaninder = temp % 10;
            reversed = reversed * 10 + remaninder;
            temp /= 10;
        }

        return number == reversed;
    }

    // public static bool IsPalindromeSlow(int number) =>
    //     number.ToString() == string.Concat(number.ToString().Reverse());

    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor) =>
        GetExtremePalindrome(minFactor, maxFactor, CompareMode.Max);

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor) =>
        GetExtremePalindrome(minFactor, maxFactor, CompareMode.Min);
}
