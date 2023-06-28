package circular

import "errors"

type Buffer struct {
	bytes    []byte
	capacity int
}

func NewBuffer(size int) *Buffer {
	return &Buffer{bytes: make([]byte, 0, size), capacity: size}
}

func (b *Buffer) ReadByte() (byte, error) {
	if len(b.bytes) == 0 {
		return 0, errors.New("empty buffer")
	}

	v := b.bytes[0]
	b.bytes = b.bytes[1:]
	return v, nil
}

func (b *Buffer) WriteByte(c byte) error {
	if len(b.bytes) == b.capacity {
		return errors.New("full buffer")
	}

	b.bytes = append(b.bytes, c)
	return nil
}

func (b *Buffer) Overwrite(c byte) {
	if len(b.bytes) < b.capacity {
		b.bytes = append(b.bytes, c)
	} else {
		b.bytes = append(b.bytes[1:], c)
	}
}

func (b *Buffer) Reset() {
	b.bytes = make([]byte, 0, b.capacity)
}
