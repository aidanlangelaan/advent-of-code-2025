using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day05 : SolutionBase
{
    public override int Day => 05;

    public override object PartOne(string[] input)
    {
        var ranges = GetRangesFromInput(input);
        var ingredients = GetIngredientsFromInput(input);

        var mergedRanges = MergeRanges(ranges);

        return ingredients.Count(ingredient =>
            mergedRanges.Any(r => r.min <= ingredient && ingredient <= r.max));
    }

    public override object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private static List<(long min, long max)> MergeRanges(IEnumerable<(long min, long max)> ranges)
    {
        var sorted = ranges.Select(r => r.min <= r.max ? r : (r.max, r.min))
            .OrderBy(r => r.Item1)
            .ToList();

        var result = new List<(long min, long max)>();
        foreach (var (min, max) in sorted)
        {
            if (result.Count == 0)
            {
                result.Add((min, max));
                continue;
            }

            var (lMin, lMax) = result[^1];

            if (min <= lMax + 1)
            {
                result[^1] = (lMin, Math.Max(lMax, max));
            }
            else
            {
                result.Add((min, max));
            }
        }
        return result;
    }

    private static List<long> GetIngredientsFromInput(string[] input)
    {
        return input
            .SkipWhile(line => !string.IsNullOrWhiteSpace(line))
            .Skip(1)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(long.Parse)
            .ToList();
    }

    private static List<(long min, long max)> GetRangesFromInput(string[] input)
    {
        return input
            .TakeWhile(line => !string.IsNullOrWhiteSpace(line))
            .Select(line =>
            {
                var parts = line.Split('-', StringSplitOptions.TrimEntries);
                long min = long.Parse(parts[0]);
                long max = long.Parse(parts[1]);
                return (min, max);
            })
            .ToList();
    }
}
