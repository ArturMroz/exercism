(ns raindrops)

(defn convert [n]
  (cond-> nil
    (zero? (mod n 3)) (str "Pling")
    (zero? (mod n 5)) (str "Plang")
    (zero? (mod n 7)) (str "Plong")
    :always (or (str n))))
