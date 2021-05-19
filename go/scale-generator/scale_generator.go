package scale

const scaleLen = 12

var sharp = [scaleLen]string{"A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"}
var flat = [scaleLen]string{"A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab"}

// Scale generates the musical scale starting with given tonic and following
// given interval pattern.
func Scale(tonic, interval string) []string {
	scale := []string{}
	switch tonic {
	case "C", "a", "G", "D", "A", "E", "B", "F#", "e", "b", "f#", "c#", "g#", "d#":
		scale = sharp[:]
	case "F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb":
		scale = flat[:]
	}

	// uppercase tonic if first char is lowercase
	if tonic[0] > 'a' {
		t := []byte(tonic)
		t[0] -= 32
		tonic = string(t)
	}

	idx := 0
	for i, v := range scale {
		if tonic == v {
			idx = i
			break
		}
	}

	if interval == "" {
		return append(scale[idx:], scale[:idx]...)
	}

	ret := make([]string, 0, 8)
	for _, v := range interval {
		ret = append(ret, scale[idx%scaleLen])
		switch v {
		case 'M':
			idx += 2
		case 'A':
			idx += 3
		default:
			idx++
		}
	}
	return ret
}
