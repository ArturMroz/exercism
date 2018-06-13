using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class NucleotideCount
{
    private const string nucleotides = "ACGT";
    private IDictionary<char, int> nucleotideCounts;

    public NucleotideCount(string sequence)
    {
        sequence = sequence.Trim().ToUpper();

        if (Regex.IsMatch(sequence, $"[^{nucleotides}]"))
        {
            throw new InvalidNucleotideException();
        }

        nucleotideCounts = nucleotides.ToDictionary(k => k, k => sequence.Count(x => x == k));
    }

    public IDictionary<char, int> NucleotideCounts { get => nucleotideCounts; }
}

public class InvalidNucleotideException : Exception { }
