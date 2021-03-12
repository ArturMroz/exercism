(ns nucleotide-count)

(def nucleotides {\A 0, \T 0, \C 0, \G 0})

(defn count-of-nucleotide-in-strand [nucleotide strand]
  {:pre [(nucleotides nucleotide)]}
  (count (filter #{nucleotide} strand)))

(defn nucleotide-counts [strand]
  (into nucleotides (frequencies strand)))
