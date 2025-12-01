namespace AdventOfCode.Core.Extensions;

public static class NumbersExtensions
{
    /// <summary>
    /// Always returns a positive modulo in the range [0..mod-1].
    /// Equivalent to Python's x % mod.
    /// </summary>
    public static int PositiveMod(this int value, int mod)
        => ((value % mod) + mod) % mod;

    public static long PositiveMod(this long value, long mod)
        => ((value % mod) + mod) % mod;

    /// <summary>
    /// Integer floor-division.
    /// Equivalent to Python's value // divisor.
    /// </summary>
    public static int FloorDiv(this int value, int divisor)
    {
        int q = value / divisor; // truncate toward zero
        int r = value % divisor; // remainder has same sign as value

        if (value < 0 && r != 0)
            q--; // shift towards negative infinity

        return q;
    }

    public static long FloorDiv(this long value, long divisor)
    {
        long q = value / divisor;
        long r = value % divisor;

        if (value < 0 && r != 0)
            q--;

        return q;
    }
}
