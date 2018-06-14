using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var digits = number.ToString().Select(char.GetNumericValue);
        var noOfDigits = digits.Count();

        return digits.Sum(x => Math.Pow(x, noOfDigits)) == number;
    }
}