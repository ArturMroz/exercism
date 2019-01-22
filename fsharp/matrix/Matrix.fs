module Matrix

let parse (matrix : string) =
    matrix.Split '\n'
    |> Array.map (fun row -> row.Split ' ' |> Array.map int)

let row index matrix =
    (parse matrix).[index] |> Array.toList

let column index matrix =
    [ for row in parse matrix -> row.[index] ]
