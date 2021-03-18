(ns rna-transcription)

(def rna->dna
  {\G \C
   \C \G
   \T \A
   \A \U})

(defn to-rna [dna]
  (let [translated (map rna->dna dna)]
    (if (some nil? translated)
      (throw (AssertionError. "Invalid strand"))
      (apply str translated))))
