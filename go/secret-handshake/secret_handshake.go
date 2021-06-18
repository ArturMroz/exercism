package secret

var actions = [4]string{"wink", "double blink", "close your eyes", "jump"}

// Handshake converts a number into a sequence of actions for a secret handshake.
func Handshake(code uint) []string {
	result := make([]string, 0, len(actions))
	for i := 0; i < 4; i++ {
		if code&(1<<i) != 0 {
			result = append(result, actions[i])
		}
	}
	if code&(1<<4) != 0 {
		for i, j := 0, len(result)-1; i < j; i, j = i+1, j-1 {
			result[i], result[j] = result[j], result[i]
		}
	}
	return result
}
