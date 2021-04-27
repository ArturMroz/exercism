package allergies

var allergens = [...]string{
	"eggs",
	"peanuts",
	"shellfish",
	"strawberries",
	"tomatoes",
	"chocolate",
	"pollen",
	"cats",
}

var allergenCodes = map[string]byte{
	"eggs":         1 << 0,
	"peanuts":      1 << 1,
	"shellfish":    1 << 2,
	"strawberries": 1 << 3,
	"tomatoes":     1 << 4,
	"chocolate":    1 << 5,
	"pollen":       1 << 6,
	"cats":         1 << 7,
}

func Allergies(input uint) []string {
	result := make([]string, 0, len(allergens))
	score := byte(input)
	for i := 0; score > 0; i++ {
		if score&1 == 1 {
			result = append(result, allergens[i])
		}
		score >>= 1
	}
	return result
}

func AllergicTo(score uint, allergen string) bool {
	return allergenCodes[allergen]&byte(score) > 0
}
