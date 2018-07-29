using System;
using System.Linq;

public static class Diamond
{
    private static readonly char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();

    public static string Make(char target)
    {
        var letterIndex = Array.IndexOf(alphabet, target);
        var diamondSize = (letterIndex * 2) + 1;
        var diamond = new string[diamondSize];

        for (int i = 0; i <= letterIndex; i++)
        {
            var curLine = Enumerable.Repeat(' ', letterIndex + 1).ToArray();
            curLine[i] = alphabet[i];
            var curLineMirrored = curLine.Reverse().Concat(curLine.Skip(1));

            diamond[i] = diamond[diamondSize - 1 - i] = string.Concat(curLineMirrored);
        }

        return string.Join('\n', diamond);
    }
}