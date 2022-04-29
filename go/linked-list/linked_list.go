package linkedlist

import (
	"errors"
)

type Node struct {
	Value      interface{}
	next, prev *Node
}

type List struct {
	head, last *Node
}

var ErrEmptyList = errors.New("empty list")

func NewList(args ...interface{}) *List {
	l := &List{}
	for _, v := range args {
		l.PushBack(v)
	}

	return l
}

func (n *Node) Next() *Node {
	if n == nil {
		return nil
	}

	return n.next
}

func (n *Node) Prev() *Node {
	if n == nil {
		return nil
	}

	return n.prev
}

func (l *List) PushFront(v interface{}) {
	node := &Node{Value: v, prev: nil, next: l.head}
	if l.head != nil {
		l.head.prev = node
	} else { // list is empty, need to set Last node
		l.last = node
	}
	l.head = node
}

func (l *List) PushBack(v interface{}) {
	node := &Node{Value: v, prev: l.last, next: nil}
	if l.last != nil {
		l.last.next = node
	} else { // list is empty, need to set First node
		l.head = node
	}
	l.last = node
}

func (l *List) PopFront() (interface{}, error) {
	if l.head == nil {
		return nil, ErrEmptyList
	}

	val := l.head.Value
	second := l.head.next
	if second == nil {
		l.last = nil // list is empty now
	} else {
		second.prev = nil
	}
	l.head = second

	return val, nil
}

func (l *List) PopBack() (interface{}, error) {
	if l.last == nil {
		return nil, ErrEmptyList
	}

	val := l.last.Value
	lastButOne := l.last.prev
	if lastButOne == nil {
		l.head = nil // list is empty now
	} else {
		lastButOne.next = nil
	}
	l.last = lastButOne

	return val, nil
}

func (l *List) Reverse() {
	cur := l.head
	for cur != nil {
		cur.prev, cur.next = cur.next, cur.prev
		cur = cur.prev
	}

	l.head, l.last = l.last, l.head
}

func (l *List) First() *Node {
	return l.head
}

func (l *List) Last() *Node {
	return l.last
}
