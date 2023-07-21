module ResistorColors (Color (..), Resistor (..), label, ohms) where

data Color
  = Black
  | Brown
  | Red
  | Orange
  | Yellow
  | Green
  | Blue
  | Violet
  | Grey
  | White
  deriving (Show, Enum, Bounded)

newtype Resistor = Resistor {bands :: (Color, Color, Color)}
  deriving (Show)

label :: Resistor -> String
label resistor
  | value > 10 ^ 9 = show (value `div` (10 ^ 9)) ++ " gigaohms"
  | value > 10 ^ 6 = show (value `div` (10 ^ 6)) ++ " megaohms"
  | value > 10 ^ 3 = show (value `div` (10 ^ 3)) ++ " kiloohms"
  | otherwise = show value ++ " ohms"
  where
    value = ohms resistor

ohms :: Resistor -> Int
ohms (Resistor (a, b, c)) = (10 * colorToInt a + colorToInt b) * (10 ^ colorToInt c)

colorToInt :: Color -> Int
colorToInt color =
  case color of
    Black -> 0
    Brown -> 1
    Red -> 2
    Orange -> 3
    Yellow -> 4
    Green -> 5
    Blue -> 6
    Violet -> 7
    Grey -> 8
    White -> 9
