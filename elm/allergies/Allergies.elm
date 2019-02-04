module Allergies exposing (isAllergicTo, toList)

import Bitwise
import Dict


allergens : Dict.Dict String Int
allergens =
    Dict.fromList
        [ ( "eggs", 1 )
        , ( "peanuts", 2 )
        , ( "shellfish", 4 )
        , ( "strawberries", 8 )
        , ( "tomatoes", 16 )
        , ( "chocolate", 32 )
        , ( "pollen", 64 )
        , ( "cats", 128 )
        ]


isValueInMask : Int -> Int -> Bool
isValueInMask value mask =
    Bitwise.and value mask == value


isAllergicTo : String -> Int -> Bool
isAllergicTo name score =
    case allergens |> Dict.get name of
        Just value ->
            isValueInMask value score

        Nothing ->
            False


toList : Int -> List String
toList score =
    allergens
        |> Dict.filter (\_ v -> isValueInMask v score)
        |> Dict.keys
        |> List.sort
