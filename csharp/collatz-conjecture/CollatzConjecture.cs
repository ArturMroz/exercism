using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0) throw new ArgumentException("Integer has to be positive");

        int steps = 0;
        while (number > 1)
        {
            steps++;
            if (number % 2 == 0) number /= 2;
            else number = 3 * number + 1;
        }

        return steps;
    }
}