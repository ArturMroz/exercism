module IsbnVerifier (isbn) where

import Data.Char (digitToInt, isDigit)

isbn :: String -> Bool
isbn xs = length digits == 10 && checksum `mod` 11 == 0
  where
    digits = isbnToDigits xs
    checksum = sum $ zipWith (*) digits [10, 9 .. 1]

isbnToDigits :: String -> [Int]
isbnToDigits [] = []
isbnToDigits ['X'] = [10]
isbnToDigits (x : xs)
  | isDigit x = digitToInt x : isbnToDigits xs
  | otherwise = isbnToDigits xs
