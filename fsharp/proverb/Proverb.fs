module Proverb

let recite (input: string list): string list =
    let rec reciteRec poem = function
        | [] -> []
        | [_] -> 
            let verse = sprintf "And all for the want of a %s." (Seq.head input) 
            verse::poem
        | head::tail -> 
            let verse = sprintf "For want of a %s the %s was lost." head (Seq.head tail)
            reciteRec (verse::poem) tail

    reciteRec [] input |> List.rev