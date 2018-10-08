using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        if (string.IsNullOrEmpty(number)) return false;

        number = number.Replace("-", string.Empty);

        var regex = new Regex(@"^(\d{9}(?:\d|X))$");
        if (!regex.IsMatch(number)) return false;

        var multiplier = 10;
        var checksum = number.Sum(d => char.GetNumericValue(d) * multiplier--);

        return checksum % 11 == 0;
    }
}