def is_isogram(string):
    string = ''.join(ch for ch in string if ch.isalnum()).lower()
    return len(string) == len(set(string))
