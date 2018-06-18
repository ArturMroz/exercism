def to_rna(dna_strand):
    rna_trans = {'G': 'C',
                 'C': 'G',
                 'T': 'A',
                 'A': 'U'}

    rna = []
    for nucleotide in dna_strand:
        if nucleotide not in rna_trans:
            raise ValueError("DNA strand contains invalid nucleotide(s)")
        else:
            rna += rna_trans[nucleotide]

    return ''.join(rna)
