module Isogram

let isIsogram (str: string) =
    let trimmed = str.ToLower() |> Seq.filter System.Char.IsLetter

    Seq.length (set trimmed) = Seq.length trimmed