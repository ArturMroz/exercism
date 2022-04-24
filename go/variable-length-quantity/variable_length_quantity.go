package variablelengthquantity

import "errors"

func EncodeVarint(input []uint32) []byte {
	result := []byte{}

	for _, v := range input {
		// rightmost byte will have its leftmost bit cleared
		low8Bits := byte(v & 0x7F)
		current := []byte{low8Bits}

		for v >>= 7; v != 0; v >>= 7 {
			current = append(current, byte(v|0x80))
		}
		for i := len(current) - 1; i >= 0; i-- {
			result = append(result, current[i])
		}
	}

	return result
}

func DecodeVarint(input []byte) ([]uint32, error) {
	if input[len(input)-1]&0x80 != 0 {
		return nil, errors.New("incomplete sequence")
	}

	result := []uint32{}
	decoded := uint32(0)

	for _, v := range input {
		decoded = (decoded << 7) | uint32(v&0x7F)

		// new sequence of bytes as the leftmost bit is clear
		if v&0x80 == 0 {
			result = append(result, decoded)
			decoded = 0
		}
	}

	return result, nil
}
