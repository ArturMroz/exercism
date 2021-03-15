(ns atbash-cipher
  (:require [clojure.string :as str]))

(def plain->cipher
  (zipmap "abcdefghijklmnopqrstuvwxyz0123456789"
          "zyxwvutsrqponmlkjihgfedcba0123456789"))

(defn encode [text]
  (->> text
       (str/lower-case)
       (map plain->cipher)
       (remove nil?)
       (partition-all 5)
       (map str/join)
       (str/join " ")))
