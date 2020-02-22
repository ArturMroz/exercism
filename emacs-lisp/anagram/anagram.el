;;; anagram.el --- Anagram (exercism)

;;; Commentary:

;;; Code:

(defun anagramp (word1 word2)
  "Check if WORD1 is an anagram of WORD2."
  (and
   (not (string= word1 word2)) ; word isn't an anagram of itself
   (string=
    (seq-sort #'> (downcase word1))
    (seq-sort #'> (downcase word2)))))

(defun anagrams-for (word candidates)
  "Return anagrams of WORD inside CANDIDATES."
  (seq-filter
   (apply-partially #'anagramp word)
   candidates))

(provide 'anagram)
;;; anagram.el ends here
