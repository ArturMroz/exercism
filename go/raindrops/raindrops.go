// Package raindrops provides a handy method to convert a number into the sounds
// of the rain (integer -> nature).
package raindrops

import "strconv"

// Convert converts a number into a string that contains raindrop sounds
// corresponding to certain potential factors.
func Convert(n int) string {
	result := ""

	if n%3 == 0 {
		result += "Pling"
	}
	if n%5 == 0 {
		result += "Plang"
	}
	if n%7 == 0 {
		result += "Plong"
	}

	if result == "" {
		result = strconv.Itoa(n)
	}

	return result
}
