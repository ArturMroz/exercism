module Proverb

let recite (input: string list): string list =
    let rec reciteRec poem  = function
        | [] -> []
        | [x] -> 
            let verse = sprintf "And all for the want of a %s." input.Head 
            verse::poem
        | head::tail -> 
            let verse = sprintf "For want of a %s the %s was lost." head tail.Head
            reciteRec (verse::poem) tail

    reciteRec [] input |> List.rev
