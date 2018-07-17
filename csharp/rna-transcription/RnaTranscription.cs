using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    private static readonly Dictionary<char, char> transcriptionMap =
        new Dictionary<char, char>
        {
            ['G'] = 'C',
            ['C'] = 'G',
            ['T'] = 'A',
            ['A'] = 'U'
        };

    public static string ToRna(string nucleotide) =>
        String.Concat(nucleotide.Select(n => transcriptionMap[n]));
}