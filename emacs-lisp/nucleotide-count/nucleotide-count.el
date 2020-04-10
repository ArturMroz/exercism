;;; nucleotide-count.el --- nucleotide-count Exercise (exercism)

;;; Commentary:

;;; Code:


(defun nucleotide-count (strand)
  "Count occurences of each nucleotide in STRAND."
  (let ((counter `((?A . 0)
                   (?C . 0)
                   (?G . 0)
                   (?T . 0))))
    (loop for nucleotide across strand
          do (incf (alist-get nucleotide counter)))
    counter))

(defun nucleotide-count2 (strand)
  "Count occurences of each nucleotide in STRAND."
  (let ((counter (list (cons ?A 0)
                       (cons ?C 0)
                       (cons ?G 0)
                       (cons ?T 0))))
    (mapcar (lambda (elt)
              (unless (member elt '(?A ?C ?G ?T))
                (error "Invalid strand"))
              (cl-incf (alist-get elt counter)))
            strand)
    counter))

(provide 'nucleotide-count)
;;; nucleotide-count.el ends here
