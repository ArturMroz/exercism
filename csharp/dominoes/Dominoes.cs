using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (!dominoes.Any()) return true;


        var freeStones = dominoes.Skip(1).ToList();
        var chain = new List<(int, int)> { dominoes.First() };

        return Backtrack();

        bool Backtrack()
        {
            if (!freeStones.Any()) return chain.First().Item1 == chain.Last().Item2;

            foreach (var stone in freeStones.ToList())
            {
                var last = chain.Last().Item2;

                if (!(last == stone.Item1 || last == stone.Item2)) continue;

                var stoneToAdd = last == stone.Item1 ? stone : (stone.Item2, stone.Item1);

                freeStones.Remove(stone);
                chain.Add(stoneToAdd);

                if (Backtrack()) return true;

                chain.Remove(stoneToAdd);
                freeStones.Add(stone);
            }

            return false;
        }
    }
}