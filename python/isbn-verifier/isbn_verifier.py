import re


def verify(isbn):
    isbn = isbn.replace("-", "")
    pattern = re.compile(r"^(\d{9}(?:\d|X))$")

    if pattern.match(isbn):
        arr = list(isbn)
        if arr[-1] == "X":
            arr[-1] = 10

        checksum = 0
        for i, number in enumerate(arr[::-1], 1):
            checksum += int(number) * i

        return checksum % 11 == 0
    else:
        return False
