using System;
using System.Linq;

public static class Minesweeper
{
  public static string[] Annotate(string[] input)
  {
    return input.Select((row, y) =>
      String.Concat(row.Select((_, x) => GetMinesCount(x, y))))
      .ToArray();

    char GetMinesCount(int x, int y)
    {
      if (input[y][x] == '*') return input[y][x];

      var range = Enumerable.Range(-1, 3);
      var neighbours = range.SelectMany(a => range.Select(b => (x: x + a, y: y + b)));
      var adjacentMinesSum = neighbours.Sum(n => Score(n.x, n.y));

      return adjacentMinesSum == 0 ? ' ' : adjacentMinesSum.ToString()[0];
    }

    int Score(int x, int y)
    {
      if (0 > y || y >= input.Length) return 0;
      if (0 > x || x >= input[y].Length) return 0;

      return input[y][x] == '*' ? 1 : 0;
    }
  }

  public static string[] Annotate_woLINQ(string[] input)
  {
    var result = new string[input.Length];

    for (int y = 0; y < input.Length; y++)
    {
      var curRow = input[y].ToCharArray();

      for (int x = 0; x < input[y].Length; x++)
      {
        if (input[y][x] == '*') continue;

        var neigbours = new[] { (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1) };
        int counter = 0;

        foreach (var (xWalk, yWalk) in neigbours)
        {
          try
          {
            if (input[y + yWalk][x + xWalk] == '*') counter++;
          }
          catch (IndexOutOfRangeException) { }
        }

        curRow[x] = counter == 0 ? ' ' : counter.ToString()[0];
      }

      result[y] = new string(curRow);
    }

    return result;
  }
}