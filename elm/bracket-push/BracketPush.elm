module BracketPush exposing (isPaired)

import Dict exposing (Dict)


brackets : Dict Char Char
brackets =
    Dict.fromList [ ( '[', ']' ), ( '{', '}' ), ( '(', ')' ) ]


isPaired : String -> Bool
isPaired input =
    input
        |> String.foldl folder []
        |> List.isEmpty


folder : Char -> List Char -> List Char
folder x stack =
    case Dict.get x brackets of
        Just closing ->
            closing :: stack

        Nothing ->
            if List.head stack == Just x then
                List.drop 1 stack

            else if brackets |> Dict.values |> List.member x then
                x :: stack

            else
                stack
