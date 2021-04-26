package summultiples

// SumMultiples finds the sum of all the unique multiples of particular numbers
// up to but not including the given number.
func SumMultiples(limit int, divisor ...int) int {
	sum := 0
	for i := 1; i < limit; i++ {
		for _, d := range divisor {
			if d == 0 {
				continue
			}
			if i%d == 0 {
				sum += i
				break
			}
		}
	}
	return sum
}
