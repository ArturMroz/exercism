(ns clock)

(defn clock->string [clock]
  (format "%02d:%02d" (quot clock 60) (mod clock 60)))

(defn clock [hours minutes]
  (-> (* hours 60)
      (+ minutes)
      (mod (* 24 60))))

(defn add-time [old-clock time]
  (clock 0 (+ old-clock time)))
