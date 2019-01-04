module Bob

open System.Text.RegularExpressions

let (|Shout|_|) (input: string) =
    if input = input.ToUpper() && Regex.IsMatch(input, "[a-zA-Z]") then Some Shout else None

let (|Question|_|) (input: string) =
    if input.EndsWith('?') then Some Question else None

let response (input: string): string =
    match input.Trim() with 
    | Question & Shout -> "Calm down, I know what I'm doing!"
    | Question -> "Sure."
    | Shout -> "Whoa, chill out!"
    | "" -> "Fine. Be that way!"
    | _ -> "Whatever."