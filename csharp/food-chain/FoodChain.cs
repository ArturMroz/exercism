using System.Linq;
using System.Text;

public static class FoodChain
{
    const string firstLine = "I know an old lady who swallowed a {0}.\n";
    const string swallowedLine = "She swallowed the {0} to catch the {1}.\n";
    static (string, string)[] animals =  {
        ("fly", "I don't know why she swallowed the fly. Perhaps she'll die."),
        ("spider", "It wriggled and jiggled and tickled inside her.\n"),
        ("bird", "How absurd to swallow a bird!\n"),
        ("cat", "Imagine that, to swallow a cat!\n"),
        ("dog", "What a hog, to swallow a dog!\n"),
        ("goat", "Just opened her throat and swallowed a goat!\n"),
        ("cow", "I don't know how she swallowed a cow!\n"),
        ("horse", "She's dead, of course!")
    };

    public static string Recite(int verseNumber)
    {
        var i = verseNumber - 1;
        var poem = new StringBuilder();

        poem.AppendFormat(firstLine, animals[i].Item1);
        poem.Append(animals[i].Item2);

        // last verse is just two lines (swallowing a horse)
        if (i == 7) return poem.ToString();

        while (i > 0)
        {
            var swallowedAnimal = animals[i - 1].Item1;
            if (swallowedAnimal == "spider")
                swallowedAnimal += " that wriggled and jiggled and tickled inside her";

            poem.AppendFormat(swallowedLine, animals[i].Item1, swallowedAnimal);
            i--;
        }

        if (verseNumber > 1) poem.Append(animals[0].Item2);

        return poem.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = Enumerable
            .Range(startVerse, endVerse - startVerse + 1)
            .Select(i => Recite(i));

        return string.Join("\n\n", verses);
    }
}