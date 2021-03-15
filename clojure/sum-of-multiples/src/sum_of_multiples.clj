(ns sum-of-multiples)

(defn sum-of-multiples [factors n]
  (->> factors
       (mapcat #(range % n %))
       (set)
       (apply +)))
