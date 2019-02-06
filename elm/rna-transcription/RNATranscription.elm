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
    dna
        |> String.foldr
            (translate >> Result.map2 String.cons)
            (Ok "")
