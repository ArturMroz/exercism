;;; leap.el --- Leap exercise (exercism)

;;; Commentary:

;;; Code:

(defun leap-year-p (year)
  "Check if given YEAR is a leap year."
  (and (zerop (mod year 4))
       (or (plusp (mod year 100))
           (zerop (mod year 400)))))

(provide 'leap-year-p)
;;; leap.el ends here
