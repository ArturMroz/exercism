using System;
using System.Linq;

public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    static readonly Random _rnd = new Random();

    public DndCharacter()
    {
        Strength = Ability();
        Dexterity = Ability();
        Constitution = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Hitpoints = 10 + Modifier(Constitution);
    }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability() =>
        Enumerable
            .Range(0, 4)
            .Select(_ => _rnd.Next(1, 7))
            .OrderBy(v => v)
            .Skip(1)
            .Sum();

    public static DndCharacter Generate() => new DndCharacter();
}
