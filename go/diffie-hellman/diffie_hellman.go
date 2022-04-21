package diffiehellman

import (
	"crypto/rand"
	"math/big"
)

// Diffie-Hellman-Merkle key exchange
// Private keys should be generated randomly.

var _two = big.NewInt(2)

func PrivateKey(p *big.Int) *big.Int {
	// because rand.Int returns a num between [0, n) and we want a num [2, n),
	// we subtract 2 from upperBound and then add it back
	upperBound := new(big.Int).Sub(p, _two)
	key, err := rand.Int(rand.Reader, upperBound)
	if err != nil {
		panic(err)
	}

	return key.Add(key, _two)
}

func PublicKey(private, p *big.Int, g int64) *big.Int {
	return new(big.Int).Exp(big.NewInt(g), private, p)
}

func NewPair(p *big.Int, g int64) (*big.Int, *big.Int) {
	privateKey := PrivateKey(p)
	publicKey := PublicKey(privateKey, p, g)
	return privateKey, publicKey
}

func SecretKey(private1, public2, p *big.Int) *big.Int {
	return new(big.Int).Exp(public2, private1, p)
}
