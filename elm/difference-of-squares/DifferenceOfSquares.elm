module DifferenceOfSquares exposing (difference, squareOfSum, sumOfSquares)


squared : number -> number
squared n =
    n ^ 2


squareOfSum : Int -> Int
squareOfSum n =
    List.range 1 n |> List.sum |> squared


sumOfSquares : Int -> Int
sumOfSquares n =
    List.range 1 n |> List.map squared |> List.sum


difference : Int -> Int
difference n =
    squareOfSum n - sumOfSquares n
