module NucleotideCount exposing (nucleotideCounts)


type alias NucleotideCounts =
    { a : Int
    , t : Int
    , c : Int
    , g : Int
    }


increment : Char -> NucleotideCounts -> NucleotideCounts
increment nucleotide counts =
    case Char.toLower nucleotide of
        'a' ->
            { counts | a = counts.a + 1 }

        't' ->
            { counts | t = counts.t + 1 }

        'c' ->
            { counts | c = counts.c + 1 }

        'g' ->
            { counts | g = counts.g + 1 }

        _ ->
            counts


nucleotideCounts : String -> NucleotideCounts
nucleotideCounts sequence =
    sequence
        |> String.foldl increment (NucleotideCounts 0 0 0 0)
