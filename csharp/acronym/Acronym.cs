using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var firstLettersOfWords = Regex.Matches(phrase, @"\b\w");
        return string.Concat(firstLettersOfWords.Select(letter => letter.Value)).ToUpper();
    }
}