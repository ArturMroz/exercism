(ns anagram
  (:require [clojure.string :as str]))

(defn- normalise [word]
  (sort (str/lower-case word)))

(defn anagrams-for [word prospect-list]
  (->> prospect-list
       (filter #(and (not= (str/lower-case %) (str/lower-case word))
                     (= (normalise %) (normalise word))))))
