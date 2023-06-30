{-# LANGUAGE LambdaCase #-}

module DNA (toRNA) where

toRNA :: String -> Either Char String
toRNA = mapM complement
  where
    complement :: Char -> Either Char Char
    complement = \case
      'G' -> Right 'C'
      'C' -> Right 'G'
      'T' -> Right 'A'
      'A' -> Right 'U'
      err -> Left err