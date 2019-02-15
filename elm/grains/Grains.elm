module Grains exposing (square)


square : Int -> Maybe Int
square n =
    if n > 0 then
        2 ^ (n - 1) |> Just
        -- bits shifting overflows already at n = 32
        -- 1 |> Bitwise.shiftLeftBy (n - 1) |> Just

    else
        Nothing
