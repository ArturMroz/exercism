package erratum

import "fmt"

// Use opens a resource, calls Frob(input) on the result resource and then
// closes that resource
func Use(o ResourceOpener, input string) (err error) {
	var res Resource
	for {
		res, err = o()
		if err != nil {
			if _, ok := err.(TransientError); ok {
				continue
			} else {
				return err
			}
		}
		break
	}

	defer res.Close()

	defer func() {
		if r := recover(); r != nil {
			frobErr, ok := r.(FrobError)
			if ok {
				res.Defrob(frobErr.defrobTag)
				err = frobErr.inner
			} else {
				err = fmt.Errorf("%s", r)
			}
		}
	}()

	res.Frob(input)

	return nil
}
