using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{
    private readonly int[,] matrix;

    public SaddlePoints(int[,] values)
    {
        matrix = values;
    }

    public IEnumerable<Tuple<int, int>> Calculate()
    {
        var (width, height) = (matrix.GetLength(0), matrix.GetLength(1));

        var rowMaxes = Enumerable.Range(0, height)
            .Select(x => Enumerable.Range(0, width).Max(y => matrix[x, y]));

        var colMins = Enumerable.Range(0, width)
            .Select(y => Enumerable.Range(0, height).Min(x => matrix[x, y]));

        return rowMaxes
            .SelectMany((rowMax, x) => colMins
                .Select((colMin, y) => (colMin: colMin, y: y))
                .Where(point => rowMax == point.colMin)
                .Select(point => (x, point.y).ToTuple())
            );
    }
}