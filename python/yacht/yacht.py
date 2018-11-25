from collections import Counter

# Score categories
# Change the values as you see fit
YACHT = 0
ONES = 1
TWOS = 2
THREES = 3
FOURS = 4
FIVES = 5
SIXES = 6
FULL_HOUSE = 7
FOUR_OF_A_KIND = 8
LITTLE_STRAIGHT = 9
BIG_STRAIGHT = 10
CHOICE = 11


def score(dice, category):
    if category is YACHT:
        if len(set(dice)) == 1:
            return 50
    elif category in [ONES, TWOS, THREES, FOURS, FIVES, SIXES]:
        return dice.count(category) * category
    elif category is FULL_HOUSE:
        if sorted(Counter(dice).values()) == [2, 3]:
            return sum(dice)
    elif category is FOUR_OF_A_KIND:
        value, cnt = Counter(dice).most_common(1)[0]
        if cnt >= 4:
            return value * 4
    elif category is LITTLE_STRAIGHT:
        if sorted(dice) == [1, 2, 3, 4, 5]:
            return 30
    elif category is BIG_STRAIGHT:
        if sorted(dice) == [2, 3, 4, 5, 6]:
            return 30
    elif category is CHOICE:
        return sum(dice)
    return 0
