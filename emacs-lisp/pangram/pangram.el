;;; pangram.el --- Pangram (exercism)

;;; Commentary:

;;; Code:

(require 'seq)


(defun is-pangram (word)
  "Check if WORD is a pangram."
  (thread-last word
    (downcase)
    (seq-filter (lambda (c) (and (>= c ?a) (<= c ?z))))
    (seq-uniq)
    (seq-length)
    (= 26)))

(defun is-pangram2 (word)
  "Check if WORD is a pangram."
  (let ((alphabet "abcdefghijklmnopqrstuvwxyz")
        (downcased (downcase word)))
    (seq-every-p
     (apply-partially #'seq-contains-p downcased)
     alphabet)))


(provide 'pangram)
;;; pangram.el ends here
