(ns series)

(defn slices [string length]
  (if (zero? length)
    [""]
    (loop [remaining string
           result    []]
      (if (< (count remaining) length)
        result
        (recur (rest remaining)
               (conj result
                     (apply str (take length remaining))))))))
