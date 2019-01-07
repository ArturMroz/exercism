module SumOfMultiples

let sum (numbers: int list) (upperBound: int): int =
    let multiples = [ for x in numbers do
                        if x = 0 then yield 0 else
                            let mutable n = 1
                            while x * n < upperBound do
                                yield x * n
                                n <- n + 1
    ]

    multiples
    |> set
    |> Seq.sum