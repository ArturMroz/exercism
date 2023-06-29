module Bob (responseFor) where

import Data.Char (isAlpha, isSpace, isLower)

import Data.List (dropWhileEnd)

responseFor :: String -> String
responseFor xs
  | isSilence                = "Fine. Be that way!"
  | isShouting && isQuestion = "Calm down, I know what I'm doing!"
  | isShouting               = "Whoa, chill out!"
  | isQuestion               = "Sure."
  | otherwise                = "Whatever."
  where
    trimWhitespace = dropWhile isSpace . dropWhileEnd isSpace
    trimmed = trimWhitespace xs
    isSilence = null trimmed
    isShouting = not (any isLower trimmed) && any isAlpha trimmed
    isQuestion = last trimmed == '?'