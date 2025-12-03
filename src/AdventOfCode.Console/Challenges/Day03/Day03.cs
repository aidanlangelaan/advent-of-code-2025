using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day03 : SolutionBase
{
    public override int Day => 03;

    public override object PartOne(string[] input)
    {
        var banks = input.Select(line => line.Select(c => c - '0').ToArray());

        var highValues = new List<int>();

        foreach (var digits in banks)
        {
            int best = -1;
            int maxSuffix = digits[^1];

            for (int i = digits.Length - 2; i >= 0; i--)
            {
                best = Math.Max(best, 10 * digits[i] + maxSuffix);
                if (digits[i] > maxSuffix)
                {
                    maxSuffix = digits[i];
                }
            }

            highValues.Add(best);
        }

        return highValues.Sum();
    }

    public override object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}
