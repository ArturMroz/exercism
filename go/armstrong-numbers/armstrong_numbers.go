package armstrong

// IsNumber checks whether a given number is an Armstrong Number
func IsNumber(number int) bool {
	expt := 0
	for n := number; n > 0; n /= 10 {
		expt++
	}

	sum := 0
	for n := number; n > 0; n /= 10 {
		digit := n % 10
		power := 1
		for i := 0; i < expt; i++ {
			power *= digit
		}
		sum += power
	}

	return number == sum
}
