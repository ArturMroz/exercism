(ns difference-of-squares)

(defn- square [n] (* n n))

(defn sum-of-squares [n]
  (->> (inc n)
       (range 1)
       (map square)
       (reduce +)))

(defn square-of-sum [n]
  (->> (inc n)
       (range 1)
       (reduce +)
       square))

(defn difference [n]
  (- (square-of-sum n)
     (sum-of-squares n)))
