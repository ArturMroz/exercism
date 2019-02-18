using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var freqMap = new ConcurrentDictionary<char, int>();

        Parallel.ForEach(texts, text =>
        {
            foreach (var ch in text.ToLower().Where(char.IsLetter))
            {
                freqMap.AddOrUpdate(ch, 1, (k, v) => v + 1);
            }
        });

        return new Dictionary<char, int>(freqMap);
    }
}