module Luhn exposing (valid)


valid : String -> Bool
valid input =
    let
        trimmed =
            input |> String.filter ((/=) ' ')
    in
    if containsInvalidChars trimmed then
        False

    else
        trimmed
            |> String.split ""
            |> List.filterMap String.toInt
            |> List.reverse
            |> List.indexedMap luhnDigit
            |> List.sum
            |> modBy 10
            |> (==) 0


containsInvalidChars : String -> Bool
containsInvalidChars input =
    String.length input <= 1 || String.any (not << Char.isDigit) input


luhnDigit : Int -> Int -> Int
luhnDigit index digit =
    if modBy 2 index == 0 then
        digit

    else
        let
            doubled =
                digit * 2
        in
        if doubled > 9 then
            doubled - 9

        else
            doubled
