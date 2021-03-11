(ns bob
  (:require [clojure.string :as str]))

(defn- shout? [s]
  (and (= s (str/upper-case s))
       (re-find #"[a-zA-Z]" s)))

(defn- question? [s]
  (str/ends-with? (str/trimr s) "?"))

(defn response-for [s]
  (cond
    (and (shout? s)
         (question? s)) "Calm down, I know what I'm doing!"
    (shout? s)          "Whoa, chill out!"
    (question? s)       "Sure."
    (str/blank? s)      "Fine. Be that way!"
    :else               "Whatever."))
