using System;
using System.Collections.Generic;

public static class BracketPush
{
  private static readonly Dictionary<char, char> _brackets = new Dictionary<char, char>
  {
      {'{', '}'},
      {'[', ']'},
      {'(', ')'},
  };

  public static bool IsPaired(string input)
  {
    var stack = new Stack<char>();

    foreach (var ch in input)
    {
      if (_brackets.ContainsKey(ch)) stack.Push(_brackets[ch]);
      else if (_brackets.ContainsValue(ch))
      {
        if (stack.Count == 0) return false;
        if (stack.Pop() != ch) return false;
      }
    }

    return stack.Count == 0;
  }
}