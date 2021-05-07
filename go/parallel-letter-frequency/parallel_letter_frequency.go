package letter

// FreqMap records the frequency of each rune in a given text.
type FreqMap map[rune]int

// Frequency counts the frequency of each rune in a given text and returns this
// data as a FreqMap.
func Frequency(s string) FreqMap {
	m := FreqMap{}
	for _, r := range s {
		m[r]++
	}
	return m
}

// ConcurrentFrequency counts the frequency of each rune in a given array of
// texts and returns this data as a FreqMap.
func ConcurrentFrequency(ss []string) FreqMap {
	c := make(chan FreqMap, 8)
	for _, s := range ss {
		go func(s string) {
			m := FreqMap{}
			for _, r := range s {
				m[r]++
			}
			c <- m
		}(s)
	}

	m := FreqMap{}
	for range ss {
		for k, v := range <-c {
			m[k] += v
		}
	}
	return m
}
