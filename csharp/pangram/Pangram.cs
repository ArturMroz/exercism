using System;
using System.Linq;

public static class Pangram
{
  private const string _alphabet = "abcdefghijklmnopqrstuvwxyz";

  public static bool IsPangram(string input)
  {
    return _alphabet.All(input.ToLower().Contains);
  }
}
