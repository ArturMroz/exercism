;;; allergies.el --- Allergies Exercise (exercism)

;;; Commentary:

;;; Code:

(defvar allergens
  '(("eggs" . 1)
    ("peanuts" . 2)
    ("shellfish" . 4)
    ("strawberries" . 8)
    ("tomatoes" . 16)
    ("chocolate" . 32)
    ("pollen" . 64)
    ("cats" . 128)))

(defun allergen-list (allergies)
  "Get a list of allergens based on ALLERGIES mask."
  (thread-last allergens
    (seq-filter (lambda (elt)
                  (/= 0 (logand (cdr elt) allergies))))
    (seq-map #'car)))

(defun allergic-to-p (allergies allergen)
  "Check if a subject with ALLERGIES mask is alergic to a specific ALLERGEN."
  (member allergen (allergen-list allergies)))


(provide 'allergies)
