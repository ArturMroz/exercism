using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class FlattenArray
{
    private static IEnumerable<object> FlattenRecursive(IEnumerable<object> array) => 
        array.SelectMany(x => x is IEnumerable<object> subArray ? FlattenRecursive(subArray) : new[] { x });

    public static IEnumerable Flatten(IEnumerable input) => 
        FlattenRecursive(input.Cast<object>()).Where(x => x != null);
}