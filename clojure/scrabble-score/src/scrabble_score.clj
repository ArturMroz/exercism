(ns scrabble-score
  (:require [clojure.string :as str]))

(defn score-letter [letter]
  (condp contains? (str/upper-case letter)
    #{"A" "E" "I" "O" "U" "L" "N" "R" "S" "T"} 1
    #{"D" "G"}                                 2
    #{"B" "C" "M" "P"}                         3
    #{"F" "H" "V" "W" "Y"}                     4
    #{"K"}                                     5
    #{"J" "X"}                                 8
    #{"Q" "Z"}                                 10
    0
    ))

(defn score-word [word]
  (reduce + (map score-letter word)))
