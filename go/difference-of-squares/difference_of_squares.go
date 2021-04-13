package diffsquares

// SquareOfSum calculates the square of sum for a given number
func SquareOfSum(n int) int {
	res := (n + 1) * n / 2
	return res * res
}

// SumOfSquares calculates the sum of squares for a given number
func SumOfSquares(n int) int {
	return n * (n + 1) * (2*n + 1) / 6
}

// Difference calculates the difference between square of sum
// and sum of square for a given number
func Difference(n int) int {
	return SquareOfSum(n) - SumOfSquares(n)
}
