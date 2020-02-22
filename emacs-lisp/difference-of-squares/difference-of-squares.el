;;; difference-of-squares.el --- Difference of Squares (exercism)

;;; Commentary:

;;; Code:

(defun square (n)
  "Calculate square of N."
  (expt n 2))

(defun square-of-sum (n)
  "Calculate square of sum of integers from 1 to N."
  (square (apply #'+ (number-sequence 1 n))))

(defun sum-of-squares (n)
  "Calculate sum of squares of integers from 1 to N."
  (apply #'+ (mapcar #'square (number-sequence 1 n))))

(defun difference (n)
  "Calculate sum of squares of integers from 1 to N."
  (- (square-of-sum n) (sum-of-squares n)))

(provide 'difference-of-squares)

;;; difference-of-squares.el ends here
