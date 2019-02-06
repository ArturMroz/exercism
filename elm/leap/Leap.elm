module Leap exposing (isLeapYear)

import Basics exposing (modBy)


isLeapYear : Int -> Bool
isLeapYear year =
    -- can't use (modBy 100 year /= 0) because of Elm compiler bug
    -- workaround is to use (not (modBy 100 year == 0)) until they patch it
    modBy 4 year == 0 && not (modBy 100 year == 0) || modBy 400 year == 0
