namespace AdventOfCode.Core.Extensions;

public static class MathExtensions
{
    /// <summary>
    /// Returns a positive modulo result in the range [0..mod-1].
    /// Equivalent to Python's x % mod.
    /// </summary>
    public static int PositiveMod(this int value, int mod)
        => ((value % mod) + mod) % mod;

    /// <summary>
    /// Returns a positive modulo result in the range [0..mod-1].
    /// Equivalent to Python's x % mod.
    /// </summary>
    public static long PositiveMod(this long value, long mod)
        => ((value % mod) + mod) % mod;

    /// <summary>
    /// Integer floor division (value // divisor).
    /// Matches Python's floor-division behavior.
    /// </summary>
    public static int FloorDiv(this int value, int divisor)
    {
        int q = value / divisor; // truncate toward zero
        int r = value % divisor; // remainder has same sign as value

        if (value < 0 && r != 0)
            q--; // shift towards negative infinity

        return q;
    }

    /// <summary>
    /// Integer floor division (value // divisor).
    /// Matches Python's floor-division behavior.
    /// </summary>
    public static long FloorDiv(this long value, long divisor)
    {
        long q = value / divisor; // truncate toward zero
        long r = value % divisor; // remainder has same sign as value

        if (value < 0 && r != 0)
            q--; // shift towards negative infinity

        return q;
    }

    /// <summary>
    /// Returns ceil(a / b) using exact integer arithmetic.
    /// </summary>
    public static long DivCeil(this long a, long b)
    {
        if (b <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(b));
        }

        if (a >= 0)
        {
            return (a + b - 1) / b;
        }

        // fallback for negative values
        return a / b;
    }

    /// <summary>
    /// Returns ceil(a / b) using exact integer arithmetic.
    /// </summary>
    public static int DivCeil(this int a, int b) => (a + b - 1) / b;

    /// <summary>
    /// Computes 10^k using integer arithmetic (0 ≤ k ≤ 18).
    /// </summary>
    public static long PowerOf10(this int k)
    {
        if (k is < 0 or > 18)
            throw new ArgumentOutOfRangeException(nameof(k));

        long v = 1;
        for (var i = 0; i < k; i++)
            v *= 10;

        return v;
    }

    /// <summary>
    /// Counts the number of decimal digits in a number.
    /// </summary>
    public static int DigitCount(this long n)
    {
        if (n == 0) return 1;

        int digits = 0;
        long x = Math.Abs(n);

        while (x > 0)
        {
            x /= 10;
            digits++;
        }

        return digits;
    }
}
