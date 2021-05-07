package perfect

import "errors"

type Classification int

const (
	ClassificationPerfect Classification = iota
	ClassificationAbundant
	ClassificationDeficient
)

var ErrOnlyPositive = errors.New("only positive vibes")

func Classify(number int64) (Classification, error) {
	if number < 1 {
		return ClassificationAbundant, ErrOnlyPositive
	} else if number == 1 {
		return ClassificationDeficient, nil
	}

	sum := int64(1)
	for i := int64(2); i*i <= number; i++ {
		if number%i == 0 {
			sum += i
			if number/i != i {
				sum += number / i
			}
		}
	}

	if sum == number {
		return ClassificationPerfect, nil
	} else if sum > number {
		return ClassificationAbundant, nil
	} else {
		return ClassificationDeficient, nil
	}
}
