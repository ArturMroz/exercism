using System;
using System.Linq;

public static class Luhn
{
  public static bool IsValid(string number)
  {
    string trimmed = number.Replace(" ", "");

    if (trimmed.Length < 2) return false;

    if (!trimmed.All(char.IsDigit)) return false;

    var luhnNumber = trimmed
        .Reverse()
        .Select(ch => (int)char.GetNumericValue(ch))
        .Select((n, i) => i % 2 != 0 ? Doubled(n) : n)
        .Sum();

    return luhnNumber % 10 == 0;
  }

  private static int Doubled(int n)
  {
    int doubled = n * 2;
    return doubled > 9 ? doubled - 9 : doubled;
  }
}