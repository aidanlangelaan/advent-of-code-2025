using AdventOfCode.Core.Classes;
using AdventOfCode.Core.Extensions;

namespace AdventOfCode.Challenges;

public class Day02 : SolutionBase
{
    public override int Day => 02;

    public override object PartOne(string[] input)
    {
        List<long> doubles = new();

        foreach (var (start, end) in ParseInput(input[0]))
        {
            var values = FindRepeatsInRange(start, end, 2).ToList();
            doubles.AddRange(values);
        }

        return doubles.Sum();
    }

    public override object PartTwo(string[] input)
    {
        List<long> doubles = new();
        foreach (var (start, end) in ParseInput(input[0]))
        {
            var values = FindRepeatsInRange(start, end).ToList();
            doubles.AddRange(values);
        }

        return doubles.Sum();
    }

    private static IEnumerable<long> FindRepeatsInRange(long start, long end, int? maxRepeats = null)
    {
        // must be at least 2 digits
        if (end < 11)
        {
            return [];
        }

        int minDigits = start.DigitCount();
        int maxDigits = end.DigitCount();

        // Gather unique values to prevent double representatives (1×6, 11×3, 111×2)
        var unique = new HashSet<long>();

        for (int k = 1; k <= maxDigits; k++)
        {
            int minM = Math.Max(2, minDigits.DivCeil(k));
            int maxM = maxRepeats.HasValue
                ? Math.Min(maxRepeats.Value, maxDigits / k)
                : (maxDigits / k);

            if (minM > maxM) continue;

            // for every m (number of repeats of H)
            for (int m = minM; m <= maxM; m++)
            {
                int totalDigits = k * m;
                if (totalDigits < minDigits || totalDigits > maxDigits)
                {
                    continue;
                }

                // N = H * S, met S = 1 + 10^k + 10^(2k) + ... + 10^((m-1)k)
                long s = BuildRepeatFactor(k, m);
                if (s <= 0) continue;

                // H needs to be like k: [10^(k-1) .. 10^k - 1]
                long pow10K = k.PowerOf10();
                long hMinDigits = pow10K / 10;
                long hMaxDigits = pow10K - 1;

                // Project range on H through N = H * S
                long hMinRange = start.DivCeil(s);
                long hMaxRange = end / s;

                long hMin = Math.Max(hMinDigits, hMinRange);
                long hMax = Math.Min(hMaxDigits, hMaxRange);
                if (hMin > hMax) continue;

                // Generate candidates (N = H * S)
                for (long h = hMin; h <= hMax; h++)
                {
                    long n = checked(h * s);

                    if (n >= start && n <= end)
                    {
                        unique.Add(n);
                    }
                }
            }
        }

        return unique;
    }

    private static long BuildRepeatFactor(int k, int m)
    {
        long step = k.PowerOf10(); // 10^k
        long term = 1;
        long sum = 0;

        checked
        {
            for (int i = 0; i < m; i++)
            {
                sum += term;
                if (i < m - 1) term *= step;
            }
        }
        return sum;
    }

    private static IEnumerable<(long start, long end)> ParseInput(string input)
    {
        foreach (var range in input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            var parts = range.Split('-', StringSplitOptions.TrimEntries);

            long start = long.Parse(parts[0]);
            long end   = long.Parse(parts[1]);

            if (start > end)
            {
                (start, end) = (end, start);
            }

            yield return (start, end);
        }
    }
}

