using System;
using System.Linq;
using System.Text;

public static class AtbashCipher
{
  private static readonly char[] _alphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();

  public static string Encode(string plainValue)
  {
    var result = new StringBuilder();
    var stripped = plainValue.ToLower().Where(ch => char.IsLetter(ch) || char.IsNumber(ch));

    foreach (var (ch, i) in stripped.Select((val, i) => (val, i + 1)))
    {
      result.Append(CodeChar(ch));
      if (i % 5 == 0) result.Append(' ');
    }

    return result.ToString().Trim();
  }

  public static string Decode(string encodedValue) =>
    String.Concat(encodedValue.Where(ch => ch != ' ').Select(CodeChar));

  private static char CodeChar(char ch)
  {
    if (!char.IsLetter(ch)) return ch;

    var index = Array.IndexOf(_alphabet, ch);
    return _alphabet[_alphabet.Length - index - 1];
  }
}
