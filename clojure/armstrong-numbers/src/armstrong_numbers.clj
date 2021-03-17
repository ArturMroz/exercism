(ns armstrong-numbers)

(defn- expt [x n]
  (reduce * (repeat n x)))

(defn- number->digits [n]
  (if (zero? n)
    ()
    (cons (mod n 10)
          (number->digits (quot n 10)))))

(defn armstrong? [num]
  (let [digits       (number->digits num)
        digits-count (count digits)
        armstrong    (->> digits
                          (map #(expt % digits-count))
                          (reduce +))]
    (= num armstrong)))
