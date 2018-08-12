using System;
using System.Linq;

public class Matrix
{
    private readonly int[][] matrix;

    public Matrix(string input)
    {
        matrix = input
            .Split('\n')
            .Select(row => row
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray())
            .ToArray();
    }

    public int Rows { get => matrix[0].Length; }

    public int Cols { get => matrix.Length; }

    public int[] Row(int row) => matrix[row];

    public int[] Column(int col) => matrix.Select(row => row[col]).ToArray();
}