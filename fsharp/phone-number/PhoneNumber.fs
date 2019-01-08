module PhoneNumber

open System

let clean (input : string) : Result<uint64, string> =
    match input with 
    | _ when input |> Seq.exists Char.IsLetter ->
        Error "alphanumerics not permitted"
    | _ when input |> Seq.exists (fun ch -> [|'@';':';'!'|] |> Seq.contains ch) ->
        Error "punctuations not permitted"
    | _ ->
        let trimmed = input |> Seq.filter Char.IsDigit |> Seq.toArray 

        match Seq.length trimmed with
        | l when l > 11 ->
            Error "more than 11 digits"
        | l when l = 11 && Seq.head trimmed <> '1' ->
            Error "11 digits must start with 1"
        | l when l < 10 ->
            Error "incorrect number of digits"
        | _ ->
            let trimmed' = trimmed |> Array.skip (Array.length trimmed - 10) 
            let errStr = sprintf "%s code cannot start with %s"

            match trimmed' with
            | t when t.[0] = '0' -> Error (errStr "area" "zero")
            | t when t.[0] = '1' -> Error (errStr "area" "one")
            | t when t.[3] = '0' -> Error (errStr "exchange" "zero")
            | t when t.[3] = '1' -> Error (errStr "exchange" "one")
            | _ -> trimmed' |> String.Concat |> uint64 |> Ok
