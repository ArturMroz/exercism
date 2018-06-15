using System;

public struct Clock
{
    private const int minutesInHour = 60;
    private const int hoursInDay = 24;

    public Clock(int hours, int minutes)
    {
        var hoursOverflow = minutes / minutesInHour;
        minutes %= minutesInHour;
        if (minutes < 0)
        {
            minutes += minutesInHour;
            hours -= 1;
        }
        Minutes = minutes;

        hours += hoursOverflow;
        hours %= hoursInDay;
        if (hours < 0) hours += hoursInDay;
        Hours = hours;
    }

    public int Hours { get; private set; }

    public int Minutes { get; private set; }

    public Clock Add(int minutesToAdd) => 
        new Clock(this.Hours, this.Minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => 
        new Clock(this.Hours, this.Minutes - minutesToSubtract);

    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";
}