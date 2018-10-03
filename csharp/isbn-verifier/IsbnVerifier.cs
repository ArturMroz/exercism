using System;
using System.Linq;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        if (string.IsNullOrEmpty(number)) return false;

        number = number.Replace("-", string.Empty);

        var isValid = number.Length == 10
                   && number.Take(number.Length - 1).All(d => char.IsDigit(d))
                   && (char.IsDigit(number.Last()) || number.Last() == 'X');

        if (!isValid) return false;

        var multiplier = 10;
        var checksum = number.Sum(d => char.GetNumericValue(d) * multiplier--);

        return checksum % 11 == 0;
    }
}