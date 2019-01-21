module Series

let slices str length =
    if length <= 0 || length > String.length str then None
    else
        str
        |> Seq.windowed length
        |> Seq.map System.String.Concat
        |> Seq.toList
        |> Some