module Bob

let (|Shout|_|) (input: string) =
    if input = input.ToUpper() && input <> input.ToLower() then Some Shout else None

let (|Question|_|) (input: string) =
    if input.EndsWith('?') then Some Question else None

let response (input: string): string =
    match input.Trim() with 
    | "" -> "Fine. Be that way!"
    | Question & Shout -> "Calm down, I know what I'm doing!"
    | Question -> "Sure."
    | Shout -> "Whoa, chill out!"
    | _ -> "Whatever."