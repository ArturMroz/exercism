module Acronym (abbreviate) where
import Data.Char ( isUpper, toLower, toUpper )

abbreviate :: String -> String
abbreviate s = map (toUpper . head) abbreviatedWords
  where
    abbreviatedWords = words (replaceDashes s) >>= splitWordCase

    splitWordCase :: String -> [String]
    splitWordCase str
      | str == map toUpper str || str == map toLower str = [str]
      | otherwise = map (: "") (filter isUpper str)

    replaceDashes :: String -> String
    replaceDashes = map (\c -> if c `notElem` "-_" then c else ' ')
