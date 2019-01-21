module Anagram

let findAnagrams (sources: string list) (target: string): string list =
    let sort (str: string) = str.ToLower() |> Seq.sort |> Seq.toArray

    sources
    |> List.filter (fun x -> x.ToLower() <> target.ToLower()
                             && sort x = sort target)
