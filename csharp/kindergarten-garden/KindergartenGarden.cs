using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    private const int rowsPerStudent = 2;
    private readonly string diagram;
    private readonly string[] students = @"Alice, Bob, Charlie, David, Eve, Fred, Ginny, 
                                  Harriet, Ileana, Joseph, Kincaid, Larry".Split(", ");

    public KindergartenGarden(string diagram)
    {
        this.diagram = diagram;
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var offset = Array.IndexOf(students, student) * rowsPerStudent;

        return diagram.Split("\n")
                .SelectMany(row => row.Substring(offset, rowsPerStudent))
                .Select(p => (Plant)p);
    }
}