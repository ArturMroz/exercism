package encode

import (
	"strconv"
	"strings"
)

func RunLengthEncode(input string) string {
	b := strings.Builder{}
	count := 1
	for i := 0; i < len(input); i++ {
		if i < len(input)-1 && input[i] == input[i+1] {
			count++
		} else {
			if count > 1 {
				b.WriteString(strconv.Itoa(count))
			}
			b.WriteByte(input[i])
			count = 1
		}
	}
	return b.String()
}

func RunLengthDecode(input string) string {
	b := strings.Builder{}
	b.Grow(len(input) * 2)
	count := 0
	for _, r := range input {
		if r > '0' && r < '9' {
			count = count*10 + int(r-'0')
		} else {
			if count == 0 {
				count = 1
			}
			for ; count > 0; count-- {
				b.WriteRune(r)
			}
		}
	}
	return b.String()
}
