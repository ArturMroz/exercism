using System;
using System.Linq;

public static class RotationalCipher
{
  public static string Rotate(string text, int shiftKey) => 
    new string(text.Select(ch =>
      {
        if (!char.IsLetter(ch)) return ch;

        var start = char.IsUpper(ch) ? 'A' : 'a';
        var offset = (ch - start + shiftKey) % 26;
        return (char)(start + offset);
      })
      .ToArray());
}