package forth

import (
	"errors"
	"strconv"
	"strings"
)

func Forth(input []string) ([]int, error) {
	stack := []int{}
	userDefined := map[string][]string{}

	for _, v := range input {
		tokens := strings.Fields(v)
		cursor := 0

		for cursor < len(tokens) {
			curToken := tokens[cursor]

			userDef, ok := userDefined[curToken]
			if ok {
				// inject user defined stuff
				tokens = append(tokens[:cursor], append(userDef, tokens[cursor+1:]...)...)
				// fmt.Println(tokens)
			} else {
				switch curToken {
				case "+":
					if len(stack) <= 1 {
						return nil, errors.New("not enough values on the stack")
					}

					result := 0
					for _, v := range stack {
						result += v
					}
					stack = []int{result}

				case "-":
					if len(stack) <= 1 {
						return nil, errors.New("not enough values on the  stack")
					}

					result := stack[0]
					for i := 1; i < len(stack); i++ {
						result -= stack[i]
					}
					stack = []int{result}

				case "*":
					if len(stack) <= 1 {
						return nil, errors.New("not enough values on the  stack")
					}

					result := 1
					for _, v := range stack {
						result *= v
					}
					stack = []int{result}

				case "/":
					if len(stack) <= 1 {
						return nil, errors.New("not enough values on the  stack")
					}

					result := stack[0]
					for i := 1; i < len(stack); i++ {
						if stack[i] == 0 {
							return nil, errors.New("dividing by zero")
						}
						result /= stack[i]
					}

					stack = []int{result}

				case "dup":
					if len(stack) == 0 {
						return nil, errors.New("couldn't duplicate: empty stack")
					}

					stackTop := stack[len(stack)-1]
					stack = append(stack, stackTop)

				case "drop":
					if len(stack) == 0 {
						return nil, errors.New("couldn't drop: empty stack")
					}

					stack = stack[:len(stack)-1]

				case "swap":
					if len(stack) <= 1 {
						return nil, errors.New("couldn't swap: not enough values on the stack")
					}

					stack[len(stack)-2], stack[len(stack)-1] = stack[len(stack)-1], stack[len(stack)-2]

				case "over":
					if len(stack) <= 1 {
						return nil, errors.New("couldn't over: not enough values on the stack")
					}

					stack = append(stack, stack[len(stack)-2])

				case ":":
					cursor++
					newWord := tokens[cursor]

					cursor++
					definition := []string{}
					for tokens[cursor] != ";" {
						definition = append(definition, tokens[cursor])
						cursor++
					}

					userDefined[newWord] = definition

				default:
					myInt, err := strconv.Atoi(curToken)
					if err != nil {
						return nil, errors.New("couldn't cast to int: " + curToken)
					}
					stack = append(stack, myInt)
				}

				cursor++
			}

		}
	}

	return stack, nil

}
