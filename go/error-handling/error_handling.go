package erratum

import "fmt"

// Use opens a resource, calls Frob(input) on the result resource and then
// closes that resource
func Use(o ResourceOpener, input string) (err error) {
	var res Resource
	res, err = o()
	for err != nil {
		if _, ok := err.(TransientError); !ok {
			return err
		}
		res, err = o()
	}
	defer res.Close()

	defer func() {
		if r := recover(); r != nil {
			switch rerr := r.(type) {
			case FrobError:
				res.Defrob(rerr.defrobTag)
				err = rerr.inner
			case error:
				err = rerr
			default:
				err = fmt.Errorf("%s", rerr)
			}
		}
	}()

	res.Frob(input)

	return nil
}
