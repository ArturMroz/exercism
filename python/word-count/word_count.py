from collections import Counter
import re


def word_count(phrase):
    phrase = phrase.replace("_", " ").lower()
    words = re.findall(r'\w+\'?\w|\w', phrase)
    return Counter(words)
