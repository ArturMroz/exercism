(ns phone-number
  (:require [clojure.string :as str]))

(defn number [num-string]
  (let [cleaned   (str/replace num-string #"\D" "")
        validated (re-matches #"1?([2-9]\d\d[2-9]\d{6})"
                                cleaned)]
    (if validated
      (second validated)
      "0000000000")))

(defn area-code [num-string]
  (subs (number num-string) 0 3))

(defn pretty-print [num-string]
  (str/replace (number num-string)
               #"(\d{3})(\d{3})(\d{3})"
               "($1) $2-$3"))
