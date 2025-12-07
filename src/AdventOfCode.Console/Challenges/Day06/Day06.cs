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
        int width = input.Max(l => l.Length);
        var grid = input
            .Select(line => line.PadRight(width, ' ').ToCharArray())
            .ToList();

        var operations = GetOperations(grid[^1]);

        var total = 0L;

        foreach (var operation in operations)
        {
            var numbers = new List<long>();
            for (var i = operation.minColumn; i <= operation.maxColumn; i++)
            {
                var columnChars = new List<char>();
                for (var j = 0; j < grid.Count - 1; j++)
                {
                    columnChars.Add(grid[j][i]);
                }

                var numberString = new string(columnChars.ToArray()).Trim();
                if (long.TryParse(numberString, out var number))
                {
                    numbers.Add(number);
                }
            }

            long result = operation.operation switch
            {
                '+' => numbers.Sum(),
                '*' => numbers.Aggregate(1L, (a, b) => a * b),
                _ => throw new InvalidOperationException(
                    $"Unknown operator '{operation.operation}' in columns {operation.minColumn}-{operation.maxColumn}")
            };

            total += result;
        }

        return total;
    }

    private static List<(char operation, int minColumn, int maxColumn)> GetOperations(char[] operatorsRow)
    {
        var operations = new List<(char operation, int minColumn, int maxColumn)>();

        int rowLength = operatorsRow.Length;
        int position = 0;

        while (position < rowLength)
        {
            while (position < rowLength && char.IsWhiteSpace(operatorsRow[position]))
            {
                position++;
            }

            if (position >= rowLength) break;

            char operation = operatorsRow[position];
            int minColumn = position;

            var scan = position + 1;
            while (scan < rowLength && char.IsWhiteSpace(operatorsRow[scan]))
            {
                scan++;
            }

            var maxColumn = (scan < rowLength) ? scan - 1 : rowLength - 1;
            operations.Add((operation, minColumn, maxColumn));

            position = scan;
        }

        return operations;
    }
}
