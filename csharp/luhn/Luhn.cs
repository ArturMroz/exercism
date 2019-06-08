using System;
using System.Linq;

public static class Luhn
{
  public static bool IsValid(string number)
  {
    string trimmed = number.Replace(" ", "");

    if (trimmed.Length < 2) return false;

    if (!trimmed.All(char.IsDigit)) return false;

    var luhnChecksum = trimmed
      .Reverse()
      .Select(char.GetNumericValue)
      .Select((n, i) => i % 2 != 0 ? n * 2 : n)
      .Select(n => n > 9 ? n - 9 : n)
      .Sum();

    return luhnChecksum % 10 == 0;
  }
}