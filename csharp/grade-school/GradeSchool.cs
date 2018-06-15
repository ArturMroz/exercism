using System;
using System.Collections.Generic;
using System.Linq;
public class School
{
    private Dictionary<string, int> school = new Dictionary<string, int>();

    public void Add(string student, int grade)
    {
        school.TryAdd(student, grade);
    }

    public IEnumerable<string> Roster()
    {
        return school.OrderBy(x => x.Value)
            .ThenBy(x => x.Key)
            .Select(x => x.Key);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return school.Where(x => x.Value == grade)
            .Select(x => x.Key)
            .OrderBy(x => x);
    }
}