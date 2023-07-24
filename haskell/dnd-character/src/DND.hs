{-# LANGUAGE RecordWildCards #-}

module DND ( Character(..)
           , ability
           , modifier
           , character
           ) where

import Test.QuickCheck (Gen, choose)
import Control.Monad (replicateM)
import Data.List (sort)

data Character = Character
  { strength     :: Int
  , dexterity    :: Int
  , constitution :: Int
  , intelligence :: Int
  , wisdom       :: Int
  , charisma     :: Int
  , hitpoints    :: Int
  }
  deriving (Show, Eq)

modifier :: Int -> Int
modifier n =
  (n - 10) `div` 2

ability :: Gen Int
ability = replicateM 4 (choose (1, 6)) >>= (pure . sum . tail . sort)

character :: Gen Character
character = do
  strength      <- ability
  dexterity     <- ability
  constitution  <- ability
  intelligence  <- ability
  wisdom        <- ability
  charisma      <- ability
  let hitpoints = 10 + modifier constitution
  return Character {..}
