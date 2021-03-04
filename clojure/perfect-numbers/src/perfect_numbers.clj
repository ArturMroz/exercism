(ns perfect-numbers)

(defn classify [n]
  (if (neg? n)
    (throw (IllegalArgumentException. "Negative numbers not allowed.")))
  (let [aliquot-sum (->> (range 1 n)
                         (filter #(zero? (mod n %)))
                         (apply +))]
    (condp apply [aliquot-sum n]
      = :perfect
      > :abundant
      < :deficient)))
