namespace AdventOfCode.Core.Extensions;

public static class ArrayExtensions
{
    public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T val)
    {
        return values.Select((b,i) => object.Equals(b, val) ? i : -1).Where(i => i != -1).ToArray();
    }
}
