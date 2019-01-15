module AllYourBase

let rebase digits inputBase outputBase =
    match digits with
    | _ when inputBase <= 1 || outputBase <= 1 -> None
    | d when d |> List.exists (fun d -> d < 0 || d >= inputBase) -> None
    | [] -> Some [0]
    | _ -> 
        let base10 = digits |> List.fold (fun acc v -> acc * inputBase + v) 0
        match base10 with
        | 0 -> Some [0]
        | _ ->
            base10
            |> List.unfold (function
                | 0 -> None
                | x -> Some (x % outputBase, x / outputBase))
            |> List.rev
            |> Some