using AdventOfCode.Core.Classes;
using AdventOfCode.Core.Extensions;
using AdventOfCode.Core.Helpers;

namespace AdventOfCode.Challenges;

public class Day04 : SolutionBase
{
    public override int Day => 04;

    public override object PartOne(string[] input)
    {
        var grid = GridHelper.ParseCharGrid(input);

        var rollCount = ProcessGrid(ref grid);

        return rollCount;
    }

    public override object PartTwo(string[] input)
    {
        var grid = GridHelper.ParseCharGrid(input);

        var totalRolls = 0;
        int rollCount;

        do
        {
            rollCount = ProcessGrid(ref grid, withReplace: true);
            totalRolls += rollCount;

        } while (rollCount > 0);

        return totalRolls;
    }

    private static int ProcessGrid(ref char[][] grid, bool withReplace = false)
    {
        var found = new List<(int row, int col)>();

        for (var y = 0; y < grid.Length; y++)
        {
            var row = grid[y];
            var rollIndices = row.FindAllIndexof('@');

            foreach (var x in rollIndices)
            {
                var neighbours = GridHelper.GetNeighboursForIndex8(grid, x, y);

                var adjacentRolls = 0;
                foreach (var (nX, nY) in neighbours)
                {
                    if (grid[nY][nX] == '@') adjacentRolls++;
                }

                if (adjacentRolls >= 4) continue;

                found.Add((y, x));
            }
        }

        if (withReplace)
        {
            foreach (var (row, col) in found)
            {
                grid[row][col] = 'x';
            }
        }

        return found.Count;
    }
}
