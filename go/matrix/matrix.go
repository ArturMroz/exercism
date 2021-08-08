package matrix

import (
	"errors"
	"strconv"
	"strings"
)

type Matrix [][]int

func New(input string) (Matrix, error) {
	lines := strings.Split(input, "\n")
	m := make(Matrix, len(lines))
	for i, line := range lines {
		fields := strings.Fields(line)
		m[i] = make([]int, len(fields))
		if len(m[0]) != len(fields) {
			return nil, errors.New("uneven rows")
		}
		for j, field := range fields {
			v, err := strconv.Atoi(field)
			if err != nil {
				return nil, err
			}
			m[i][j] = v
		}
	}
	return m, nil
}

func (m *Matrix) Rows() [][]int {
	rows := make([][]int, len(*m))
	for i, row := range *m {
		rows[i] = make([]int, len(row))
		copy(rows[i], row)
	}
	return rows
}

func (m *Matrix) Cols() [][]int {
	cols := make([][]int, len((*m)[0]))
	for i := range cols {
		cols[i] = make([]int, len(*m))
		for j := range cols[i] {
			cols[i][j] = (*m)[j][i]
		}
	}
	return cols
}

func (m *Matrix) Set(row, col, val int) bool {
	if row < 0 || col < 0 || row >= len(*m) || col >= len((*m)[0]) {
		return false
	}
	(*m)[row][col] = val
	return true
}
