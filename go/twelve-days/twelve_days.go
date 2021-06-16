package twelve

import (
	"fmt"
	"strings"
)

var (
	verseFmt = "On the %s day of Christmas my true love gave to me: %s."

	gifts = []string{
		"a Partridge in a Pear Tree",
		"two Turtle Doves",
		"three French Hens",
		"four Calling Birds",
		"five Gold Rings",
		"six Geese-a-Laying",
		"seven Swans-a-Swimming",
		"eight Maids-a-Milking",
		"nine Ladies Dancing",
		"ten Lords-a-Leaping",
		"eleven Pipers Piping",
		"twelve Drummers Drumming",
	}

	days = []string{
		"first",
		"second",
		"third",
		"fourth",
		"fifth",
		"sixth",
		"seventh",
		"eighth",
		"ninth",
		"tenth",
		"eleventh",
		"twelfth",
	}
)

// Verse outputs the given N verse of the lyrics to 'The Twelve Days of Christmas'
func Verse(n int) string {
	if n == 1 {
		return fmt.Sprintf(verseFmt, days[0], gifts[0])
	}
	result := make([]string, 0, 12)
	for i := n - 1; i >= 0; i-- {
		result = append(result, gifts[i])
	}
	result[len(result)-1] = "and " + result[len(result)-1]
	return fmt.Sprintf(verseFmt, days[n-1], strings.Join(result, ", "))
}

// Song outputs the lyrics to 'The Twelve Days of Christmas'
func Song() string {
	result := make([]string, 0, 12)
	for i := 1; i <= 12; i++ {
		result = append(result, Verse(i))
	}
	return strings.Join(result, "\n")
}
