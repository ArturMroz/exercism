using System;

public static class Darts
{
  public static int Score(double x, double y)
  {
    var furthest = Math.Max(x, y);

    if (furthest > 10) return 0;
    if (furthest > 5) return 1;
    if (furthest > 1) return 5;

    return 10;
  }
}
