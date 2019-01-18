module BracketPush

let isPaired input =
    let parens = dict [ '(',')'; '[',']'; '{','}' ] 

    let rec check input stack = 
        match input, stack with
        | x::xs, _ when parens.ContainsKey x -> 
            check xs (parens.[x]::stack)
        | x::xs, s::ss when x = s ->
            check xs ss
        | x::_, _ when parens.Values.Contains x ->
            false
        | _::xs, _ -> 
            check xs stack
        | [], [] -> true
        | [], _ -> false

    check (Seq.toList input) []