from string import ascii_lowercase


def is_pangram(sentence):
    return all((ch in sentence.lower()) for ch in ascii_lowercase)
