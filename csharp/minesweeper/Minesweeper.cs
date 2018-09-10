using System;
using System.Linq;

public static class Minesweeper
{
    private static bool IsMine(int x, int y, string[] input)
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

    public static string[] Annotate(string[] input)
    {
        var resultBoard = new string[input.Length];

        for (int y = 0; y < input.Length; y++)
        {
            var currentRow = string.Empty;

            for (int x = 0; x < input[0].Length; x++)
            {
                var newValue = input[y][x];

                if (input[y][x] == ' ')
                {
                    var neighbours = new[]
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

                    var adjacentMinesCount = neighbours
                        .Select(point => IsMine(point.Item1, point.Item2, input) ? 1 : 0)
                        .Sum();

                    if (adjacentMinesCount > 0) currentRow += adjacentMinesCount.ToString();
                    else currentRow += ' '; 
                }
                else if (input[y][x] == '*') currentRow += '*';
            }

            resultBoard[y] = currentRow;
        }

        return resultBoard;
    }
}
