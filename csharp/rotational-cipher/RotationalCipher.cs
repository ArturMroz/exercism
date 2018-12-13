using System;
using System.Linq;

public static class RotationalCipher
{
  private static readonly char[] _az =
    Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();

  public static string Rotate(string text, int shiftKey)
  {
    return new string(text
      .Select(ch =>
      {
        if (!char.IsLetter(ch)) return ch;

        var isUpper = char.IsUpper(ch);
        var valToRot = Array.IndexOf(_az, char.ToLower(ch)) + shiftKey;
        valToRot %= _az.Length; // wrap around alphabet

        var rotated = _az[valToRot];
        return isUpper ? char.ToUpper(rotated) : rotated;
      })
      .ToArray());
  }
}