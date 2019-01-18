module Raindrops

let convert (n: int): string =
    let res = 
        [3, "Pling"; 5, "Plang"; 7, "Plong"] 
        |> List.map (fun (i, v) -> if n % i = 0 then v else "") 
        |> String.concat ""

    if res = "" then string n else res