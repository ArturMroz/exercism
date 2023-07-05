module Hamming (distance) where

distance :: String -> String -> Maybe Int
distance xs ys =
  if length xs /= length ys
    then Nothing
    else Just $ sum $ zipWith (\x y -> (if x /= y then 1 else 0)) xs ys
