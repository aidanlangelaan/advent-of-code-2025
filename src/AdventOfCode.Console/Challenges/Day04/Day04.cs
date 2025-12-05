using AdventOfCode.Core.Classes;
using AdventOfCode.Core.Extensions;

namespace AdventOfCode.Challenges;

public class Day04 : SolutionBase
{
    public override int Day => 04;

    public override object PartOne(string[] input)
    {
        var grid = ParseInput(input);
        var rollCount = 0;

        foreach (var row in grid)
        {
            var rollIndices = row.FindAllIndexof('@');
            foreach (var rollIndex in rollIndices)
            {
                var neighbours = GetNeighboursForIndex(rollIndex, grid, row);

                var adjacentRolls = 0;
                foreach (var (x, y) in neighbours)
                {
                    if (grid[y][x] == '@')
                    {
                        adjacentRolls++;
                    }
                }

                if (adjacentRolls < 4)
                {
                    rollCount++;
                }
            }
        }

        return rollCount;
    }

    private static List<(int x, int y)> GetNeighboursForIndex(int rollIndex, char[][] grid, char[] row)
    {
        var neighbours = new List<(int x, int y)>();
        for (var y = -1; y <= 1; y++)
        {
            for (var x = -1; x <= 1; x++)
            {
                if (x == 0 && y == 0) continue; // skip self

                var newX = rollIndex + x;
                var newY = Array.IndexOf(grid, row) + y;
                if (newX >= 0 && newX < row.Length && newY >= 0 && newY < grid.Length)
                {
                    neighbours.Add((newX, newY));
                }
            }
        }

        return neighbours;
    }

    private static char[][] ParseInput(string[] input)
        => input.Select(line => line.ToArray()).ToArray();

    public override object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}
