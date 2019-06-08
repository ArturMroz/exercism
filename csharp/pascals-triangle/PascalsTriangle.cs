using System.Collections.Generic;
using System.Linq;

public static class PascalsTriangle
{
  public static IEnumerable<IEnumerable<int>> Calculate(int rows)
  {
    if (rows == 0) return Enumerable.Empty<IEnumerable<int>>();

    IEnumerable<IEnumerable<int>> firstRow = new[] { new[] { 1 } };

    return Enumerable
      .Range(1, rows - 1)
      .Aggregate(
        firstRow,
        (acc, _) => acc.Append(BuildNextRow(acc.Last()))
      );
  }

  private static IEnumerable<int> BuildNextRow(IEnumerable<int> row)
  {
    row = row.Prepend(0).Append(0);

    return row
      .Zip(row.Skip(1), (a, b) => (a, b))
      .Select(pair => pair.a + pair.b);
  }
}