using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement)) return "Fine. Be that way!";

        statement = statement.Trim();
        if (statement.Last() == '?')
        {
            if (statement == statement.ToUpper() && statement.Any(char.IsLetter))
            {
                return "Calm down, I know what I'm doing!";
            }
            else
            {
                return "Sure.";
            }
        }
        else if (statement == statement.ToUpper() && statement.Any(char.IsLetter))
        {
            return "Whoa, chill out!";
        }
        else
        {
            return "Whatever.";
        }
    }
}