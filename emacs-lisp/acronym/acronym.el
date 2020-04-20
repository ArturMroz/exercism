;;; acronym.el --- Acronym (exercism)

;;; Commentary:

;;; Code:

(defun acronym (sentence)
  "Return acronym of SENTENCE."
  (upcase
   (concat
    (mapcar #'string-to-char
            (split-string sentence "\\W+")))))

(provide 'acronym)
;;; acronym.el ends here
