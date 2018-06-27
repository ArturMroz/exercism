def hey(phrase):
    phrase = phrase.strip()
    
    if phrase.isupper() and any(c.isalpha() for c in phrase):
        if phrase.endswith('?'):
            return "Calm down, I know what I'm doing!"
        else:
            return 'Whoa, chill out!'
    elif phrase.endswith('?'):
        return 'Sure.'
    elif not phrase:
        return 'Fine. Be that way!'
    else:
        return 'Whatever.'
