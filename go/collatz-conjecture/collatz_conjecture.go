package collatzconjecture

import "errors"

func CollatzConjecture(n int) (int, error) {
	if n < 1 {
		return -1, errors.New("Only positive numbers allowed.")
	}

	steps := 0

	for n != 1 {
		steps += 1

		if n%2 == 0 {
			n = n / 2
		} else {
			n = 3*n + 1
		}
	}

	return steps, nil
}
