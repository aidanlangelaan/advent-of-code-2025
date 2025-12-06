using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day06 : SolutionBase
{
    public override int Day => 06;

    public override object PartOne(string[] input)
    {
        var grid = input
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToList();

        var total = 0L;
        for (var i = 0; i < grid[0].Length; i++)
        {
            var column = grid
                .Select(row => row[i])
                .ToList();

            var values = column.Take(column.Count - 1).Select(long.Parse).ToList();
            var operation = grid[^1][i];

            long result = operation switch
            {
                "+" => values.Sum(),
                "*" => values.Aggregate(1L, (a, b) => a * b),
                _ => throw new InvalidOperationException($"Unknown operator '{operation}' in column {i}")
            };

            total += result;
        }

        return total;
    }

    public override object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}
