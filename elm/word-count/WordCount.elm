module WordCount exposing (wordCount)

import Dict exposing (Dict)


update : Maybe Int -> Maybe Int
update v =
    v
        |> Maybe.withDefault 0
        |> (+) 1
        |> Just


isPunctuation : Char -> Bool
isPunctuation ch =
    "!&@$%^&:,"
        |> String.toList
        |> List.member ch


wordCount : String -> Dict String Int
wordCount sentence =
    sentence
        |> String.filter (isPunctuation >> not)
        |> String.toLower
        |> String.words
        |> List.foldl
            (\word -> Dict.update word update)
            Dict.empty
