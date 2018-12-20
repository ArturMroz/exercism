using System;
using System.Linq;

public static class AtbashCipher
{
  public static string Encode(string plainValue) =>
    String.Concat(plainValue
      .ToLower()
      .Where(char.IsLetterOrDigit)
      .Select(CodeChar)
      .Select((ch, i) => i != 0 && i % 5 == 0 ? $" {ch}" : $"{ch}"));

  public static string Decode(string encodedValue) =>
    String.Concat(encodedValue
      .Where(char.IsLetterOrDigit)
      .Select(CodeChar));

  private static char CodeChar(char ch) => char.IsLetter(ch) ? (char)('a' + 'z' - ch) : ch;
}
