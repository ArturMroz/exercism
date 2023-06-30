module DNA (nucleotideCounts, Nucleotide(..)) where

import Data.Foldable (foldlM)
import Data.Map (fromList, insertWith, Map) 

data Nucleotide = A | C | G | T deriving (Eq, Ord, Show)

nucleotideCounts :: String -> Either String (Map Nucleotide Int)
nucleotideCounts = foldlM countNucleotide initialMap
    where
        initialMap = fromList [(A, 0), (C, 0), (G, 0), (T, 0)]
        countNucleotide :: Map Nucleotide Int -> Char -> Either String (Map Nucleotide Int)
        countNucleotide counts ch =
            case charToNucleotide ch of
                Just nuc -> Right (insertWith (+) nuc 1 counts)
                Nothing -> Left ("invalid char" ++ [ch])

        charToNucleotide :: Char -> Maybe Nucleotide
        charToNucleotide ch = case ch of
            'A' -> Just A
            'C' -> Just C
            'G' -> Just G
            'T' -> Just T
            _   -> Nothing
