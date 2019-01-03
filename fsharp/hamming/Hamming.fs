module Hamming

let distance (strand1 : string) (strand2 : string) : int option =
    match String.length strand1 <> String.length strand2 with
    | true -> None
    | false -> 
        Seq.zip strand1 strand2
        |> Seq.filter (fun (x, y) -> x <> y)
        |> Seq.length
        |> Some