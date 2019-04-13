module Luhn

open System

let luhnDigit i x =
    if i % 2 = 0 then
        x
    else
        let x' = x * 2
        if x' > 9 then x' - 9 else x'

let valid (number : string) =
    let trimmed = number |> Seq.filter ((<>) ' ')

    if Seq.length trimmed <= 1 then
        false
    elif not (trimmed |> Seq.forall Char.IsDigit) then
        false
    else
        trimmed
        |> Seq.filter Char.IsDigit
        |> Seq.map (Char.GetNumericValue >> int)
        |> Seq.rev
        |> Seq.mapi luhnDigit
        |> Seq.sum
        |> (fun x -> x % 10)
        |> (=) 0
