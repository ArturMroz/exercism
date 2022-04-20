package forth

import (
	"errors"
	"fmt"
	"strconv"
	"strings"
)

var (
	errEmptyStack     = errors.New("empty stack")
	errStackUnderflow = errors.New("not enough values on the stack")
)

func Forth(input []string) ([]int, error) {
	stack := []int{}
	userDefined := map[string][]string{}

	for _, curLine := range input {
		tokens := strings.Fields(strings.ToLower(curLine)) // poor man's lexer
		cursor := 0

		for cursor < len(tokens) {
			curToken := tokens[cursor]

			userDef, ok := userDefined[curToken]
			if ok {
				// cheeky, inject user defined stuff into the current program
				tokens = append(tokens[:cursor], append(userDef, tokens[cursor+1:]...)...)
			} else {
				switch curToken {
				case "+":
					if len(stack) <= 1 {
						return nil, errStackUnderflow
					}
					stack[len(stack)-2] += stack[len(stack)-1]
					stack = stack[:len(stack)-1]

				case "-":
					if len(stack) <= 1 {
						return nil, errStackUnderflow
					}
					stack[len(stack)-2] -= stack[len(stack)-1]
					stack = stack[:len(stack)-1]

				case "*":
					if len(stack) <= 1 {
						return nil, errStackUnderflow
					}
					stack[len(stack)-2] *= stack[len(stack)-1]
					stack = stack[:len(stack)-1]

				case "/":
					if len(stack) <= 1 {
						return nil, errStackUnderflow
					}
					if stack[len(stack)-1] == 0 {
						return nil, errors.New("dividing by zero")
					}
					stack[len(stack)-2] /= stack[len(stack)-1]
					stack = stack[:len(stack)-1]

				case "dup":
					if len(stack) == 0 {
						return nil, fmt.Errorf("cannot dup: %w", errEmptyStack)
					}
					stack = append(stack, stack[len(stack)-1])

				case "drop":
					if len(stack) == 0 {
						return nil, fmt.Errorf("cannot drop: %w", errEmptyStack)
					}
					stack = stack[:len(stack)-1]

				case "swap":
					if len(stack) <= 1 {
						return nil, fmt.Errorf("cannot swap: %w", errStackUnderflow)
					}
					stack[len(stack)-2], stack[len(stack)-1] = stack[len(stack)-1], stack[len(stack)-2]

				case "over":
					if len(stack) <= 1 {
						return nil, fmt.Errorf("cannot over: %w", errStackUnderflow)
					}
					stack = append(stack, stack[len(stack)-2])

				case ":":
					cursor++

					wordName := tokens[cursor]
					if _, err := strconv.Atoi(wordName); err == nil {
						return nil, errors.New("cannot redefine numbers")
					}

					cursor++
					definition := []string{}
					for tokens[cursor] != ";" || cursor < len(tokens)-1 {
						if def, ok := userDefined[tokens[cursor]]; ok {
							// ugly: check if we've got "inception" situation going on
							// i.e. if the word has already been defined then unwrap it;
							// only 1 level of nesting supported
							definition = append(definition, def...)
						} else {
							definition = append(definition, tokens[cursor])
						}

						cursor++
					}

					userDefined[wordName] = definition

				default:
					parsedInt, err := strconv.Atoi(curToken)
					if err != nil {
						return nil, errors.New("unknown word: " + curToken)
					}
					stack = append(stack, parsedInt)
				}

				cursor++
			}
		}
	}

	return stack, nil
}
