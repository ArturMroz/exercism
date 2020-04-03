;;; raindrops.el --- Raindrops (exercism)

;;; Commentary:

;;; Code:


(defun convert (n)
  "Convert integer N to its raindrops string."
  (let ((retval (concat
                 (if (zerop (% n 3)) "Pling")
                 (if (zerop (% n 5)) "Plang")
                 (if (zerop (% n 7)) "Plong"))))

    (if (string= retval "")
        (number-to-string n)
      retval)))


(provide 'raindrops)

;;; raindrops.el ends here
