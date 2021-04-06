// Package isogram provides a method that determines if a given phrase
// is an isogram.
package isogram

import "unicode"

// IsIsogram determines if a given phrase is an isogram.
func IsIsogram(input string) bool {
	visited := map[rune]struct{}{}
	exists := struct{}{}
	for _, r := range input {
		if r == '-' || r == ' ' {
			continue
		}
		r = unicode.ToLower(r)
		if _, ok := visited[r]; ok {
			return false
		}
		visited[r] = exists
	}
	return true
}
