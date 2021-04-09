package strand

var rnaMap = map[byte]byte{
	'G': 'C',
	'C': 'G',
	'T': 'A',
	'A': 'U',
}

func ToRNA(dna string) string {
	rna := make([]byte, len(dna))
	for i, v := range []byte(dna) {
		rna[i] = rnaMap[v]
	}
	return string(rna)
}
