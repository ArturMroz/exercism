// Package grains provides methods helpful in the booming
// field of Applied Grain Mathematics
package grains

import "errors"

// Square returns the number of grains on a given square
func Square(n int) (uint64, error) {
	if n < 1 || n > 64 {
		return 0, errors.New("square number out of range")
	}
	return 1 << (n - 1), nil
}

// Total returns the total number of grains on the chessboard
func Total() uint64 {
	return 1<<(65-1) - 1
}
