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

    public static string[] AnnotateLongerVersion(string[] input)
    {
        var resultBoard = new string[input.Length];

        for (int y = 0; y < input.Length; y++)
        {
            var curRow = string.Empty;

            for (int x = 0; x < input[0].Length; x++)
            {
                var curField = input[y][x];

                if (curField == ' ')
                {
                    var adjacentMinesCount = GetAdjacentFields(x, y)
                        .Sum(field => IsFieldAMine(field.Item1, field.Item2, input) ? 1 : 0);

                    if (adjacentMinesCount > 0)
                    {
                        curField = adjacentMinesCount.ToString()[0];
                    }
                }

                curRow += curField;
            }

            resultBoard[y] = curRow;
        }

        return resultBoard;
    }
}
