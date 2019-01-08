module Acronym

open System
open System.Text.RegularExpressions

let abbreviate (phrase: string): string = 
    Regex.Matches(phrase, @"\b\w")
    |> Seq.map (fun x -> x.Value.ToUpper())
    |> String.Concat