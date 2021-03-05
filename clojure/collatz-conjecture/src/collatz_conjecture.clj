(ns collatz-conjecture)

(defn collatz-number [n]
  (if (even? n)
    (/ n 2)
    (inc (* 3 n))))

(defn collatz [num]
  (if (< num 1)
    (throw (Exception. "Only positive integers allowed.")))
  (->> num
       (iterate collatz-number)
       (take-while #(> % 1))
       count))
