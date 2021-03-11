(ns rna-transcription)

(def complements
  {\G \C
   \C \G
   \T \A
   \A \U})

(defn to-rna [dna]
  (let [translated (map #(get complements %) dna)]
    (if (some nil? translated)
      (throw (AssertionError. "Invalid strand"))
      (apply str translated))))
