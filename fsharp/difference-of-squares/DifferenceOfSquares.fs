﻿module DifferenceOfSquares

let square x = x * x

let squareOfSum (number: int): int =
    seq {1..number} |> Seq.sum |> square

let sumOfSquares (number: int): int =
    seq {1..number} |> Seq.sumBy square

let differenceOfSquares (number: int): int =
    squareOfSum number - sumOfSquares number