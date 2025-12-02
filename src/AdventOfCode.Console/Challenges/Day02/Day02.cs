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
            var values = FindDoublesInRange(start, end).ToList();
            doubles.AddRange(values);
        }

        return doubles.Sum();
    }

    public override object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private static IEnumerable<long> FindDoublesInRange(long start, long end)
    {
        // must be at least 2 digits
        if (end < 11) yield break;

        int minDigits = start.DigitCount();
        int maxDigits = end.DigitCount();

        // must be an even number of digits to be valid
        if ((minDigits & 1) == 1) minDigits++;
        if ((maxDigits & 1) == 1) maxDigits--;

        if (minDigits > maxDigits) yield break;

        for (int totalDigits = minDigits; totalDigits <= maxDigits; totalDigits += 2)
        {
            int k = totalDigits / 2;

            long pow10k = k.PowerOf10();
            long factor = pow10k + 1;

            // H must have k digits → [10^(k-1) .. 10^k - 1]
            long hMinDigits = pow10k / 10; // 10^(k-1)
            long hMaxDigits = pow10k - 1;  // 10^k - 1

            // To stay within [start..end]: start ≤ H*factor ≤ end
            // ⇒ H ∈ [ceil(start/factor) .. floor(end/factor)]
            long hMinRange = start.DivCeil(factor);
            long hMaxRange = end / factor;

            long hMin = Math.Max(hMinDigits, hMinRange);
            long hMax = Math.Min(hMaxDigits, hMaxRange);

            if (hMin > hMax) continue;

            for (long h = hMin; h <= hMax; h++)
            {
                yield return h * factor;
            }
        }
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

