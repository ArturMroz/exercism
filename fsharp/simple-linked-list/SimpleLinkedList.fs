module SimpleLinkedList

type LinkedList =
    | Empty
    | Node of int * LinkedList

let nil = Empty

let create x n = Node(x, n)

let isNil x = x = Empty

let next = function
    | Empty -> Empty
    | Node (_, next) -> next

let datum = function
    | Empty -> failwith "Can't get data from empty node"
    | Node (v, _) -> v

let toList =
    List.unfold (function 
        | Empty -> None 
        | Node(v, next) -> Some (v, next))

let rec fromList = function
    | [] -> Empty
    | x::xs -> Node(x, fromList xs)

let rec reverse x = 
    let rec reverseRec prev = function
        | Node (v, next) -> reverseRec (Node (v, prev)) next
        | Empty -> prev

    reverseRec Empty x