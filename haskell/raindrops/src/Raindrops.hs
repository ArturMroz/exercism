module Raindrops (convert) where

drops :: [(Int, String)]
drops =
  [ (3, "Pling")
  , (5, "Plang")
  , (7, "Plong")
  ]

convert :: Int -> String
convert number =
  if null sounds 
    then show number
    else concat sounds
  where 
    factors = filter (\(x, _) -> mod number x == 0) drops
    sounds = map snd factors
