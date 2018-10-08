using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;

    public Anagram(string baseWord)
    {
        _baseWord = baseWord;
    }

    public string[] Anagrams(string[] potentialMatches)
    {
        if (_baseWord.All(c => char.IsUpper(c))) return new string[0]; 

        var baseWordSorted = _baseWord.ToLower().OrderBy(c => c);

        return potentialMatches
            .Where(m => baseWordSorted.SequenceEqual(m.ToLower().OrderBy(c => c)))
            .ToArray();
    }
}