package robotname

import (
	"errors"
	"math/rand"
)

const (
	nameLen       = 5
	numberOfNames = 26 * 26 * 10 * 10 * 10
)

type Robot struct {
	name string
}

type namesRegistry struct {
	names    [numberOfNames][nameLen]byte
	position int
}

var reg = &namesRegistry{position: -1}

// Reset resets Robot's name
func (r *Robot) Reset() {
	r.name = ""
}

// Name names Mr Robot and returns the name
func (r *Robot) Name() (string, error) {
	if r.name != "" {
		return r.name, nil
	}

	if reg.position < 0 {
		reg.generateNames()
		reg.position = 0
	} else if reg.position >= numberOfNames {
		return "", errors.New("namespace exhausted")
	}

	name := reg.names[reg.position]
	reg.position++
	r.name = string(name[:])
	return r.name, nil
}

func (nr *namesRegistry) generateNames() {
	c := 0
	for i := byte('A'); i <= 'Z'; i++ {
		for j := byte('A'); j <= 'Z'; j++ {
			for k := byte('0'); k <= '9'; k++ {
				for l := byte('0'); l <= '9'; l++ {
					for m := byte('0'); m <= '9'; m++ {
						nr.names[c] = [...]byte{i, j, k, l, m}
						c++
					}
				}
			}
		}
	}
	rand.Shuffle(numberOfNames, func(i, j int) {
		nr.names[i], nr.names[j] = nr.names[j], nr.names[i]
	})
}
