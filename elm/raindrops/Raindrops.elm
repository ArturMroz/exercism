module Raindrops exposing (raindrops)


drops =
    [ ( 3, "Pling" )
    , ( 5, "Plang" )
    , ( 7, "Plong" )
    ]


raindrops : Int -> String
raindrops number =
    let
        result =
            drops |> List.filter (\( x, _ ) -> modBy x number == 0)
    in
    if List.isEmpty result then
        String.fromInt number

    else
        result
            |> List.map Tuple.second
            |> String.concat
