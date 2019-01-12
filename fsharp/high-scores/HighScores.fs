module HighScores

let scores (values: int list): int list = values

let latest (values: int list): int = List.last values

let highest (values: int list): int = List.max values

let top (values: int list): int list = values |> List.sortDescending |> List.truncate 3

let report (values: int list): string = 
    let latest, highest = latest values, highest values
    match highest - latest with
    | 0 -> sprintf "Your latest score was %i. That's your personal best!" latest
    | d -> sprintf "Your latest score was %i. That's %i short of your personal best!" latest d