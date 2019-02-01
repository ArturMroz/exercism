module RNATranscription exposing (toRNA)


translate : Char -> Result Char Char
translate nucleotide =
    case nucleotide of
        'C' ->
            Ok 'G'

        'G' ->
            Ok 'C'

        'T' ->
            Ok 'A'

        'A' ->
            Ok 'U'

        _ ->
            Err nucleotide


toRNA : String -> Result Char String
toRNA dna =
    case String.uncons dna of
        Nothing ->
            Ok ""

        Just ( nucleotide, dna_ ) ->
            Result.map2 String.cons (translate nucleotide) (toRNA dna_)


toRNA1 : String -> Result Char String
toRNA1 dna =
    dna
        |> String.toList
        |> List.map translate
        |> List.foldr (Result.map2 (::)) (Ok [])
        |> Result.map (List.map String.fromChar)
        |> Result.map (String.join "")
