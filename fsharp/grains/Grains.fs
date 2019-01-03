module Grains

let square (n: int): Result<uint64,string> =
    match n with
    | _ when 1 <= n && n <= 64 -> 
        Ok (1UL <<< (n - 1))
    | _ -> 
        Error "square must be between 1 and 64"

let total: Result<uint64,string> = 
    [1..64] 
    |> List.map square 
    |> List.reduce (fun a b -> 
        match a, b with
        | Ok x, Ok y -> Ok (x + y)
        | _ -> Error "Invalid input")