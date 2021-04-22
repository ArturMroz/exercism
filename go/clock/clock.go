package clock

import "fmt"

// Clock stores time
type Clock struct {
	minutes int
}

const minutesInDay = 60 * 24

// New creates a new Clock
func New(hour, minute int) Clock {
	minutes := (hour*60 + minute) % minutesInDay
	if minutes < 0 {
		minutes += minutesInDay
	}
	return Clock{minutes}
}

// Add adds minutes to a Clock
func (c Clock) Add(minutes int) Clock {
	return New(0, c.minutes+minutes)
}

// Subtract subtracts minutes from a Clock
func (c Clock) Subtract(minutes int) Clock {
	return New(0, c.minutes-minutes)
}

// String returns a nicely formatted Clock
func (c Clock) String() string {
	return fmt.Sprintf("%02d:%02d", c.minutes/60, c.minutes%60)
}
