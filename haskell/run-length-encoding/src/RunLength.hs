module RunLength (decode, encode) where

import Data.Char (isDigit)
import Data.List (group)

encode :: String -> String
encode = concatMap encoded . group
  where
    encoded [x] = [x]
    encoded xs = show (length xs) ++ take 1 xs

decode :: String -> String
decode [] = ""
decode xs = replicate len ch ++ decode rest
  where
    (lenRaw, ch : rest) = span isDigit xs
    len = if null lenRaw then 1 else read lenRaw
