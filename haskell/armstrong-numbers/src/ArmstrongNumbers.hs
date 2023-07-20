module ArmstrongNumbers (armstrong) where

armstrong :: Integral a => a -> Bool
armstrong n = n == sumOfDigits
  where
    digits = intToDigits n
    sumOfDigits = sum $ map (^ length digits) digits

intToDigits :: Integral a => a -> [a]
intToDigits 0 = []
intToDigits x = x `mod` 10 : intToDigits (x `div` 10)
