// Package hamming provides a method to calculate Hamming distance.
package hamming

import "errors"

// Distance calculates the Hamming distance of 2 given DNA strands.
func Distance(a, b string) (int, error) {
	if len(a) != len(b) {
		return 0, errors.New("strands need to be of equal length")
	}

	distance := 0
	for i := range []rune(a) {
		if a[i] != b[i] {
			distance++
		}
	}

	return distance, nil
}
