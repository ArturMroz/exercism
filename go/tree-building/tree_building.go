package tree

import (
	"errors"
	"sort"
)

type Record struct {
	ID, Parent int
}

type Node struct {
	ID       int
	Children []*Node
}

const rootID = 0

// Build parses a flat list of records into a tree
func Build(records []Record) (*Node, error) {
	if len(records) == 0 {
		return nil, nil
	}

	sort.SliceStable(records, func(a, b int) bool {
		return records[a].ID < records[b].ID
	})

	if maxID := records[len(records)-1].ID; maxID != len(records)-1 {
		return nil, errors.New("duplicated or non-continuous nodes")
	}

	nodes := make([]*Node, len(records))
	for _, v := range records {
		nodes[v.ID] = &Node{ID: v.ID}
		if v.ID == rootID {
			if v.Parent != rootID {
				return nil, errors.New("root node has parent")
			}
			continue
		}

		if v.ID <= v.Parent {
			return nil, errors.New("tree has circular reference")
		}

		parent := nodes[v.Parent]
		parent.Children = append(parent.Children, nodes[v.ID])
	}

	return nodes[rootID], nil
}
