using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class SaddlePoints
{
    private IEnumerable<int> matrix;

    public SaddlePoints(int[,] values)
    {
        matrix = values.Cast<int>();
    }

    public IEnumerable<Tuple<int, int>> Calculate()
    {
        var size = (int)Math.Sqrt(matrix.Count()); 
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                var row = matrix.Skip(size * x).Take(size).Where((_, i) => i != y);
                var column = matrix.Where((_, i) => (i - y) % size == 0).Where((_, i) => i != x);
                var current = matrix.Skip(size * x + y).First();

                if ((current >= row.Max() && current <= column.Min()))
                {
                    yield return (x, y).ToTuple();
                }
            }
        }
    }
}