module SumOfMultiples

let sum (numbers: int list) (upperBound: int): int =
    numbers
    |> Seq.collect (fun n -> if n > 0 then [n .. n .. upperBound - 1] else [0])
    |> set
    |> Seq.sum