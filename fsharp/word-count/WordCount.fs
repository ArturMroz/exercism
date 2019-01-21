module WordCount

open System.Text.RegularExpressions

let countWords (phrase: string) =
    Regex.Matches (phrase.ToLower(), @"(\w|\b'\w)+")
    |> Seq.countBy (fun x -> x.Value)
    |> Map.ofSeq