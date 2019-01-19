module QueenAttack

let create (position: int * int) =
    match position with 
    | x, y -> x >= 0 && x <= 7 && y >= 0 && y <= 7 

let canAttack (queen1: int * int) (queen2: int * int) =
    match queen1, queen2 with
    | (x1, y1), (x2, y2) -> 
        x1 = x2 || y1 = y2 || abs (x1 - x2) = abs (y1 - y2)