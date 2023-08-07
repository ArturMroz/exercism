module Yacht (yacht, Category(..)) where

import Data.List (sort, group, find)
import Data.Maybe (fromJust)

data Category = Ones
              | Twos
              | Threes
              | Fours
              | Fives
              | Sixes
              | FullHouse
              | FourOfAKind
              | LittleStraight
              | BigStraight
              | Choice
              | Yacht

yacht :: Category -> [Int] -> Int
yacht category dice = case category of
    Ones -> countDice 1
    Twos -> countDice 2
    Threes -> countDice 3
    Fours -> countDice 4
    Fives -> countDice 5
    Sixes -> countDice 6
    FullHouse -> if isFullHouse then sum dice else 0
    FourOfAKind -> if isFourOfAKind then fourOfAKindDiceSum else 0
    LittleStraight -> if isStraight [1..5] then 30 else 0
    BigStraight -> if isStraight [2..6] then 30 else 0
    Choice -> sum dice
    Yacht -> if allSame then 50 else 0
  where
    groups = group (sort dice)
    countDice number = length (filter (== number) dice) * number
    allSame = all (== head dice) dice
    isFullHouse = length groups == 2 && (length (head groups) == 2 || length (head groups) == 3)
    isFourOfAKind = any (\g -> length g >= 4) groups
    fourOfAKindDiceSum = (4 *) . head . fromJust $ find (\g -> length g >= 4) groups
    isStraight xs = sort dice == xs
