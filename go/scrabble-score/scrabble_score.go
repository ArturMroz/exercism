// Package scrabble provides a method to compute Scrable score.
package scrabble

import "strings"

func score(ch rune) int {
	switch ch {
	case 'D', 'G':
		return 2
	case 'B', 'C', 'M', 'P':
		return 3
	case 'F', 'H', 'V', 'W', 'Y':
		return 4
	case 'K':
		return 5
	case 'J', 'X':
		return 8
	case 'Q', 'Z':
		return 10
	default:
		return 1
	}
}

// Score computes the Scrabble score for given word.
func Score(word string) int {
	result := 0
	for _, ch := range strings.ToUpper(word) {
		result += score(ch)
	}
	return result
}
