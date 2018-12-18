using System;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        var grouped = dice.GroupBy(d => d).OrderByDescending(d => d.Count());

        switch (category)
        {
            case YachtCategory.Yacht:
                if (grouped.Count() == 1 && grouped.First().Count() == 5) return 50;
                break;
            case YachtCategory.Ones:
            case YachtCategory.Twos:
            case YachtCategory.Threes:
            case YachtCategory.Fours:
            case YachtCategory.Fives:
            case YachtCategory.Sixes:
                return dice.Where(d => d == (int)category).Sum();
            case YachtCategory.FullHouse:
                if (grouped.Count() == 2 && grouped.First().Count() == 3) return dice.Sum();
                break;
            case YachtCategory.FourOfAKind:
                if (grouped.Count() <= 2 && grouped.First().Count() >= 4) return grouped.First().Key * 4;
                break;
            case YachtCategory.LittleStraight:
                if (dice.OrderBy(d => d).SequenceEqual(new[] { 1, 2, 3, 4, 5 })) return 30;
                break;
            case YachtCategory.BigStraight:
                if (dice.OrderBy(d => d).SequenceEqual(new[] { 2, 3, 4, 5, 6 })) return 30;
                break;
            case YachtCategory.Choice:
                return dice.Sum();
        }

        return 0;
    }
}
