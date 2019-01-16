module Zipper

type Tree<'a> =
    | Node of 'a * Tree<'a> option * Tree<'a> option

type History<'a> =
    | Root
    | Left of 'a * History<'a> * Tree<'a> option
    | Right of 'a * History<'a> * Tree<'a> option

type TreeZipper<'a> = 
    | TZ of Tree<'a> * History<'a>

let tree value left right = Node (value, left, right)

let value = function
    | TZ (Node (v, _, _), _) -> v

let up = function
    | TZ (tree, Right (v, h, t)) -> Some (TZ (Node (v, t, Some tree), h))
    | TZ (tree, Left (v, h, t)) -> Some (TZ (Node (v, Some tree, t), h))
    | TZ (_, Root) -> None

let left = function
    | TZ (Node (v, Some l, r), h) -> TZ (l, Left (v, h, r)) |> Some
    | TZ (Node (_, None, _), _) -> None

let right = function 
    | TZ (Node (v, l, Some r), h) -> TZ (r, Right (v, h, l)) |> Some
    | TZ (Node (_, _, None), _) -> None

let fromTree = function
    // | Empty -> failwith "empty tree"
    | tree -> TZ (tree, Root)

let rec toTree = function
    | TZ (tree, Root) -> tree
    | tz -> toTree (up tz |> Option.get)

let setValue v = function
    | TZ (Node (_, l, r), h) -> TZ (Node (v, l, r), h) 

let setLeft t = function
    | TZ (Node (v, _, r), h) -> TZ (Node (v, t, r), h) 

let setRight t = function
    | TZ (Node (v, l, _), h) -> TZ (Node (v, l, t), h) 
