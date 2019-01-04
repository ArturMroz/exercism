module Darts

let score (x: double) (y: double): int =
    match max x y with
    | m when m > 10.0 -> 0
    | m when m > 5.0 -> 1
    | m when m > 1.0 -> 5
    | _ -> 10