module CollatzConjecture exposing (collatz)


collatz : Int -> Result String Int
collatz n =
    if n < 1 then
        Err "Only positive numbers are allowed"

    else if n == 1 then
        Ok 0

    else
        Result.map ((+) 1) <|
            collatz <|
                if modBy 2 n == 0 then
                    n // 2

                else
                    n * 3 + 1
