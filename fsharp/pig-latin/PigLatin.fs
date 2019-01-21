module PigLatin

let (|Prefix|_|) (prefixes: string list) (str:string) =
    prefixes 
    |> List.tryFind str.StartsWith 
    |> Option.map (fun p -> p, str.[p.Length..])

let toPigLatin = function
    | Prefix ["a";"e";"i";"o";"u";"yt";"xr"] (prefix, rest) ->
        sprintf "%s%say" prefix rest 
    | Prefix ["ch";"qu";"squ";"thr";"th";"rh";"sch"] (prefix, rest) ->
        sprintf "%s%say" rest prefix
    | word ->
        sprintf "%s%cay" word.[1..] word.[0]

let translate (input: string) = 
    input.Split ' '
    |> Seq.map toPigLatin 
    |> String.concat " "