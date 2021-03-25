(ns beer-song
  (:require [clojure.string :as str]))

(defn verse
  "Returns the nth verse of the song."
  [num]
  (case num
    2 "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n"
    1 "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n"
    0 "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n"
    (format "%d bottles of beer on the wall, %d bottles of beer.\nTake one down and pass it around, %d bottles of beer on the wall.\n"
            num num (dec num))))

(defn sing
  "Given a start and an optional end, returns all verses in this interval. If
  end is not given, the whole song from start is sung."
  ([start]
   (sing start 0))
  ([start end]
   (->> (range start (dec end) -1)
        (map verse)
        (str/join "\n"))))
