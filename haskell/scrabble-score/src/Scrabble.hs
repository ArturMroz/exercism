module Scrabble (scoreLetter, scoreWord) where

import Data.Char (toUpper)

scoreLetter :: Char -> Integer
scoreLetter letter 
  | uc `elem` "AEIOULNRST" = 1
  | uc `elem` "DG" = 2
  | uc `elem` "BCMP" = 3
  | uc `elem` "FHVWY" = 4
  | uc `elem` "K" = 5
  | uc `elem` "JX" = 8
  | uc `elem` "QZ" = 10
  | otherwise = 0
  where 
    uc = toUpper letter

scoreWord :: String -> Integer
scoreWord word = sum $ map scoreLetter word
