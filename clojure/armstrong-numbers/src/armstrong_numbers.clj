(ns armstrong-numbers)

(defn- exp [x n]
  (reduce * (repeat n x)))

(defn armstrong? [num]
  (let [stringified (str num)
        digits-count (count stringified)
        armstrong (->> stringified
                       (map #(- (int %) (int \0)))
                       (map #(exp % digits-count))
                       (reduce +))]
    (= num armstrong)))
