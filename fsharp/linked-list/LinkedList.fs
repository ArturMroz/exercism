module LinkedList

type Node = {
    mutable Datum : int 
    mutable Prev : Node option
    mutable Next : Node option
}

type LinkedList = {
    mutable First : Node option
    mutable Last : Node option
} 

let mkLinkedList () = { First = None; Last = None }

let addToEmpty newValue linkedList =
    let newNode = { Datum = newValue; Prev = None ; Next = None }
    linkedList.First <- Some newNode
    linkedList.Last <- Some newNode

let pop linkedList =
    match linkedList.Last with
    | Some last -> 
        linkedList.Last <- last.Prev
        last.Datum
    | None -> failwith "empty node"

let shift linkedList =
    match linkedList.First with
    | Some first -> 
        linkedList.First <- first.Next 
        first.Datum
    | None -> failwith "empty node"

let push newValue linkedList = 
    match linkedList.Last with
    | None -> addToEmpty newValue linkedList
    | Some last -> 
        let newNode = Some { Datum = newValue; Prev = linkedList.Last ; Next = None }
        last.Next <- newNode
        linkedList.Last <- newNode

let unshift newValue linkedList = 
    match linkedList.First with
    | None -> addToEmpty newValue linkedList
    | Some first ->
        let newNode = Some { Datum = newValue; Prev = None; Next = linkedList.First }
        first.Prev <- newNode
        linkedList.First <- newNode