using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (!dominoes.Any()) return true;

        var available = new List<(int, int)>(dominoes);
        var chain = new List<(int, int)>();

        var firstStone = available.First();
        available.Remove(firstStone);
        chain.Add(firstStone);

        return Backtrack();

        bool Backtrack()
        {
            if (!available.Any())
            {
                return chain.First().Item1 == chain.Last().Item2;
            }

            foreach (var stone in available.ToList())
            {
                available.Remove(stone);

                if (chain.Last().Item2 == stone.Item1)
                {
                    chain.Add(stone);

                    if (Backtrack()) return true;

                    chain.Remove(stone);
                }
                else if (chain.Last().Item2 == stone.Item2)
                {
                    var reversed = (stone.Item2, stone.Item1);
                    chain.Add(reversed);

                    if (Backtrack()) return true;

                    chain.Remove(reversed);
                }

                available.Add(stone);
            }

            return false;
        }
    }
}