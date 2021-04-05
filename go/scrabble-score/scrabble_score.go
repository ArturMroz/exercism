// Package scrabble provides a method to compute Scrable score.
package scrabble

import "strings"

// Score computes the Scrabble score for given word.
func Score(word string) (result int) {
	for _, ch := range strings.ToUpper(word) {
		switch ch {
		case 'D', 'G':
			result += 2
		case 'B', 'C', 'M', 'P':
			result += 3
		case 'F', 'H', 'V', 'W', 'Y':
			result += 4
		case 'K':
			result += 5
		case 'J', 'X':
			result += 8
		case 'Q', 'Z':
			result += 10
		default:
			result += 1
		}
	}
	return
}
