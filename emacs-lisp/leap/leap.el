;;; leap.el --- Leap exercise (exercism)

;;; Commentary:

;;; Code:

(defun leap-year-p (year)
  "Check if given YEAR is a leap year."
  (and (= 0 (mod year 4))
       (or (/= 0 (mod year 100))
           (= 0 (mod year 400)))))

(provide #'leap-year-p)
;;; leap.el ends here
