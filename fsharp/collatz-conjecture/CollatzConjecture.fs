module CollatzConjecture

let steps (number: int): int option =
    let rec stepsRec stepsSoFar = function
        | n when n <= 0 -> None
        | 1 -> Some stepsSoFar
        | n when n % 2 = 0 -> stepsRec (stepsSoFar + 1) (n / 2)
        | n -> stepsRec (stepsSoFar + 1) (3 * n + 1)
    
    stepsRec 0 number
