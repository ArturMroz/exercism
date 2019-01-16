module BinarySearchTree

type Node = {
    Data : int
    Left : Node option
    Right : Node option
}

let left node = node.Left
let right node = node.Right
let data node = node.Data

let create items =
    let rec insert value = function
        | Some node when value <= node.Data ->
            { node with Left = Some (insert value node.Left) }
        | Some node ->
            { node with Right = Some (insert value node.Right) }
        | None ->
            { Data = value; Left = None; Right = None }

    items 
    |> List.fold (fun acc elem -> Some (insert elem acc)) None
    |> Option.get

let sortedData node = 
    let rec flatten = function
        | Some n -> flatten n.Left @ n.Data :: flatten n.Right
        | None -> []

    flatten (Some node)