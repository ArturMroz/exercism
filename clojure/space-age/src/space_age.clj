(ns space-age)

(def earth-orbit-in-seconds 31557600)

(def orbital-periods
  {"mercury" 0.2408467
   "venus"   0.61519726
   "earth"   1
   "mars"    1.8808158
   "jupiter" 11.862615
   "saturn"  29.447498
   "uranus"  84.016846
   "neptune" 164.79132})

(defmacro create-orbital-fns []
  (let [fns (for [[planet period] orbital-periods]
              `(defn ~(symbol (str "on-" planet))
                 [seconds#]
                 (/ seconds# earth-orbit-in-seconds ~period)))]
    `(do ~@fns)))

(create-orbital-fns)
