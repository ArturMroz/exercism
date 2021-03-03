(ns perfect-numbers)

(defn classify [n]
  (if (neg? n)
    (throw (IllegalArgumentException. "Negative numbers not allowed.")))
  (let [aliquot-sum (->> (range 1 n)
                         (filter #(zero? (mod n %)))
                         (reduce +))]
    (cond
      (= aliquot-sum n) :perfect
      (> aliquot-sum n) :abundant
      (< aliquot-sum n) :deficient)))
