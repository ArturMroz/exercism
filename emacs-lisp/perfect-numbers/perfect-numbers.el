;;; perfect-numbers.el --- perfect-numbers Exercise (exercism) -*- lexical-binding: t -*-

;;; Commentary:

;;; Code:

(defun classify (number)
  "Determine if NUMBER is perfect, abundant, or deficient."

  (when (< number 1)
    (error "Classification is only possible for natural numbers"))

  (let ((aliquot-sum (apply #'+ (factors number))))
    (cond ((= number 1) 'deficient)
          ((= aliquot-sum number) 'perfect)
          ((> aliquot-sum number) 'abundant)
          (t 'deficient))))

(defun factors (number)
  "Return all factors of NUMBER."
  (let ((retval '(1))
        (i 2)
        (limit (round (sqrt number))))

    (while (<= i limit)
      (when (zerop (% number i))
        (add-to-list 'retval i)
        (add-to-list 'retval (/ number i)))
      (setq i (1+ i)))

    retval))

(provide 'perfect-numbers)
;;; perfect-numbers.el ends here
