;;; armstrong-numbers.el --- armstrong-numbers Exercise (exercism) -*- lexical-binding: t -*-

;;; Commentary:

;;; Code:

(require 'cl-lib)

(defun get-digits (n)
  "Get digits of N as a list, i.e. 123 => '(3 2 1)."
  (if (zerop n)
      '()
    (cons (% n 10) (get-digits (/ n 10)))))

(defun armstrong-p (number)
  "Check if NUMBER is an armstrong number."
  (let* ((digits (get-digits number))
         (number-of-digits (length digits))
         (armstrong-sum (reduce
                         (lambda (acc el)
                           (+ acc (expt el number-of-digits)))
                         digits
                         :initial-value 0)))
    (= number armstrong-sum)))

(defun armstrong-slow-p (number)
  "Check if NUMBER is an armstrong number, use conversion to string."
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
