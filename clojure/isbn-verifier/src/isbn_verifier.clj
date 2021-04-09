(ns isbn-verifier)

(defn- valid-format? [isbn]
  (re-matches #"\d-?\d{3}-?\d{5}-?[\dX]" isbn))

(defn- char->digit [ch]
  (if (= ch \X)
    10
    (Character/digit ch 10)))

(defn- divisible-by? [divisor n]
  (zero? (mod n divisor)))

(defn- valid-checksum? [digits]
  (->> digits
       (remove #(= % \-))
       (map char->digit)
       (map * (range 10 0 -1))
       (apply +)
       (divisible-by? 11)))

(defn isbn? [isbn]
  (boolean (and (valid-format? isbn)
                (valid-checksum? isbn))))
