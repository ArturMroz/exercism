module SaddlePoints

let saddlePoints (matrix : int list list) : (int * int) list =
    match matrix with 
    | [] | [[]] -> []
    | _ -> 
        let maxes = matrix |> List.map List.max

        let mins = 
            [ for j, _ in List.indexed matrix.Head do 
                yield [ for row in matrix do yield row.[j]]]
            |> List.map List.min

        [ for i, row in List.indexed matrix do 
            for j, el in List.indexed row do 
                if el = maxes.[i] && el = mins.[j] then yield i, j ]