using System;
using System.Linq;

public static class Minesweeper
{
    private static bool IsFieldAMine(int x, int y, string[] input)
    {
        try
        {
            return input[y][x] == '*';
        }
        catch
        {
            return false;
        }
    }

    private static (int, int)[] GetAdjacentFields(int x, int y) =>
        new[]
        {
            (x - 1, y),
            (x - 1, y - 1),
            (x - 1, y + 1),
            (x, y - 1),
            (x, y + 1),
            (x + 1, y),
            (x + 1, y - 1),
            (x + 1, y + 1),
        };

    public static string[] Annotate(string[] input) =>
        input.Select((row, y) =>
            new String(row.Select((field, x) =>
            {
                if (field == ' ')
                {
                    var adjacentMinesSum = GetAdjacentFields(x, y)
                        .Sum(af => IsFieldAMine(af.Item1, af.Item2, input) ? 1 : 0);

                    if (adjacentMinesSum > 0) return adjacentMinesSum.ToString()[0];
                }

                return field;
            }).ToArray()))
        .ToArray();

}
