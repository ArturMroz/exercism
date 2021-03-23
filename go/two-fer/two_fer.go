// Package twofer provides a handy method to help you settle
// rabid disputes when it comes to sharing with your dear friends.
package twofer

import (
	"fmt"
)

// ShareWith returns a string in a form of "One for X, one for me."
// where X is the given name
func ShareWith(name string) string {
	if name == "" {
		name = "you"
	}

	return fmt.Sprintf("One for %s, one for me.", name)
}
