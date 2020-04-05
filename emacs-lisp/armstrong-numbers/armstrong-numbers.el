;;; armstrong-numbers.el --- armstrong-numbers Exercise (exercism) -*- lexical-binding: t -*-

;;; Commentary:

;;; Code:

(require 'cl-lib)

(defun armstrong-p (number)
  "Check if NUMBER is an armstrong number."
  (let*
      ((stringified (number-to-string number))
       (number-of-digits (length stringified))
       (armstrong-sum
        (reduce
         (lambda (acc el)
           (+ acc (expt
                   (string-to-number (char-to-string el))
                   number-of-digits)))
         stringified
         :initial-value 0)))

    (= number armstrong-sum)))


(provide 'armstrong-numbers)
;;; armstrong-numbers.el ends here
