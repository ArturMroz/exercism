using System;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;

    public Anagram(string baseWord) => _baseWord = baseWord.ToLower();

    public string[] Anagrams(string[] potentialMatches) =>
        potentialMatches.Where(pm =>
           _baseWord != pm.ToLower() &&
           _baseWord.OrderBy(c => c).SequenceEqual(pm.ToLower().OrderBy(c => c)))
        .ToArray();
}