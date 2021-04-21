package luhn

func Valid(input string) bool {
	sum := 0
	length := 0

	for i := len(input) - 1; i >= 0; i-- {
		if input[i] == ' ' {
			continue
		}
		v := int(input[i] - '0')
		if v < 0 || v > 9 {
			return false
		}
		length++
		if length%2 == 0 {
			v *= 2
			if v > 9 {
				v -= 9
			}
		}
		sum += v
	}

	return length > 1 && sum%10 == 0
}
