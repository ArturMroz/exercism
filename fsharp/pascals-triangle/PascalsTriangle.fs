module PascalsTriangle


let rows = function
    | 0 -> []
    | n ->
        let nextRow curRow =
            (0 :: curRow) @ [ 0 ]
            |> List.windowed 2
            |> List.map List.sum

        [ 1..n - 1 ]
        |> List.scan (fun acc _ -> nextRow acc) [ 1 ]


let rows' n =
    let createRow i =
        [ 1..i - 1 ]
        |> List.scan (fun acc j -> acc * (i - j) / j) 1

    [ 1..n ] |> List.map createRow
