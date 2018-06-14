using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class NucleotideCount
{
    private const string nucleotides = "ACGT";

    public NucleotideCount(string sequence)
    {
        sequence = sequence.Trim().ToUpper();

        if (Regex.IsMatch(sequence, $"[^{nucleotides}]"))
        {
            throw new InvalidNucleotideException();
        }

        NucleotideCounts = nucleotides.ToDictionary(k => k, k => sequence.Count(x => x == k));
    }

    public IDictionary<char, int> NucleotideCounts { get; private set; }
}

public class InvalidNucleotideException : Exception { }