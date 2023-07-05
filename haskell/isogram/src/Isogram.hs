module Isogram (isIsogram) where

import Data.Char (isAlpha, toLower)
import Data.List (nub)

isIsogram :: String -> Bool
isIsogram xs = length (nub trimmed) == length trimmed
  where
    trimmed = filter isAlpha $ map toLower xs
