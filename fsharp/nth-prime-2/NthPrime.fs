module NthPrime

let primes = 
    let rec nextPrime n p primes =
        if primes |> Map.containsKey n then
            nextPrime (n + p) p primes
        else
            primes.Add(n, p)

    let rec prime n primes =
        seq {
            if primes |> Map.containsKey n then
                let p = primes.Item n
                yield! prime (n + 1) (nextPrime (n + p) p (primes.Remove n))
            else
                yield n
                yield! prime (n + 1) (primes.Add(n * n, n))
        }

    prime 2 Map.empty

let prime nth : int option =
    match nth with
    | 0 -> None
    | _ -> 
        primes
        |> Seq.item (nth - 1)
        |> Some