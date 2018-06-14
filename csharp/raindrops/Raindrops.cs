using System;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var output = string.Empty;
        if (number % 3 == 0) output += "Pling";
        if (number % 5 == 0) output += "Plang";
        if (number % 7 == 0) output += "Plong";

        return string.IsNullOrEmpty(output) ? number.ToString() : output;
    }
}