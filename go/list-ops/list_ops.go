package listops

type binFunc func(int, int) int
type predFunc func(int) bool
type unaryFunc func(int) int
type IntList []int

func (l IntList) Foldl(folder binFunc, acc int) int {
	for _, v := range l {
		acc = folder(acc, v)
	}
	return acc
}

func (l IntList) Foldr(folder binFunc, acc int) int {
	for i := len(l) - 1; i >= 0; i-- {
		acc = folder(l[i], acc)
	}
	return acc
}

func (l IntList) Filter(fn predFunc) IntList {
	result := make(IntList, 0, l.Length())
	i := 0
	for _, v := range l {
		if fn(v) {
			result = result[:i+1]
			result[i] = v
			i++
		}
	}
	return result

}

func (l IntList) Length() int {
	i := 0
	for range l {
		i++
	}
	return i
}

func (l IntList) Map(fn unaryFunc) IntList {
	for i := range l {
		l[i] = fn(l[i])
	}
	return l
}

func (l IntList) Reverse() IntList {
	for i, j := 0, len(l)-1; i < j; i, j = i+1, j-1 {
		l[i], l[j] = l[j], l[i]
	}
	return l
}

func (l IntList) Append(other IntList) IntList {
	count := l.Length()
	result := make(IntList, count+other.Length())
	for i, v := range l {
		result[i] = v
	}
	for i, v := range other {
		result[count+i] = v
	}
	return result
}

func (l IntList) Concat(others []IntList) IntList {
	for _, v := range others {
		l = l.Append(v)
	}
	return l
}
