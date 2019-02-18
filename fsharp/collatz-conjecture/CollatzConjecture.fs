module CollatzConjecture

let rec steps = function
    | n when n <= 0 ->
        None
    | 1 ->
        Some 0
    | n ->
        if n % 2 = 0 then n / 2 else n * 3 + 1
        |> steps
        |> Option.map ((+) 1)
