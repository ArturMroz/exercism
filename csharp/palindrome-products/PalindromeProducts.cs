using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    private static IDictionary<int, List<(int, int)>> GetProducts(int minFactor, int maxFactor)
    {
        var temp = new Dictionary<int, List<(int, int)>>();

        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                var current = i * j;
                if (IsPalindrome(current))
                {
                    var factors = (i, j);
                    if (temp.ContainsKey(current))
                    {
                        temp[current].Add(factors);
                    }
                    else
                    {
                        temp.Add(current, new List<(int, int)> { factors });
                    }
                }
            }
        }

        if (temp.Any())
        {
            return temp;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public static bool IsPalindrome(int number)
    {
        int temp = number;
        int reversed = 0;
        int remaninder;

        while (temp > 0)
        {
            remaninder = temp % 10;
            reversed = reversed * 10 + remaninder;
            temp /= 10;
        }

        return number == reversed;
    }

    // public static bool IsPalindromeSlow(int number)
    // {
    //     return number.ToString() == string.Concat(number.ToString().Reverse());
    // }

    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        var palindromes = GetProducts(minFactor, maxFactor);
        var max = palindromes.Aggregate((curMax, x) => x.Key > curMax.Key ? x : curMax);
        return (max.Key, max.Value);
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        var palindromes = GetProducts(minFactor, maxFactor);
        var min = palindromes.Aggregate((curMin, x) => x.Key < curMin.Key ? x : curMin);
        return (min.Key, min.Value);
    }
}
