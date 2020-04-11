;;; atbash-cipher.el --- Atbash-Cipher (exercism)

;;; Commentary:

;;; Code:

(defun encode (plaintext)
  "Encode PLAINTEXT to atbash-cipher encoding."
  (let* ((atbashed (seq-map
                    (lambda (c)
                      (cond ((<= ?a c ?z) (- (+ ?a ?z) c ))
                            ((<= ?0 c ?9) c)
                            (t nil)))
                    (downcase plaintext)))
         (nils-removed (remove nil atbashed))
         (chunked (seq-partition nils-removed 5)))
    (mapconcat #'concat chunked " ")))


(provide 'atbash-cipher)
;;; atbash-cipher.el ends here
