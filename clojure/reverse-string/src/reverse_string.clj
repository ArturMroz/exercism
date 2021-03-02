(ns reverse-string
  (:require [clojure.string :as str]))

(defn reverse-string [s]
  (str/join (reduce #(cons %2 %1) [] s)))
