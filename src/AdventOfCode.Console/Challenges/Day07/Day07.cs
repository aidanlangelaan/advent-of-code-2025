using AdventOfCode.Core.Classes;
using AdventOfCode.Core.Helpers;

namespace AdventOfCode.Challenges;

public class Day07 : SolutionBase
{
    public override int Day => 07;

    public override object PartOne(string[] input)
    {
        var grid = GridHelper.ParseCharGrid(input);
        int totalRows = grid.Length;
        int totalColumns = grid[0].Length;

        var startPosition = grid
            .SelectMany((row, y) => row.Select((cell, x) => (cell, x, y)))
            .Where(c => c.cell == 'S')
            .Select(c => (Column: c.x, Row: c.y))
            .First();

        var splittersByRow = new HashSet<int>[totalRows];
        for (int y = 0; y < totalRows; y++)
        {
            splittersByRow[y] = new HashSet<int>();
            for (int x = 0; x < totalColumns; x++)
            {
                if (grid[y][x] == '^')
                {
                    splittersByRow[y].Add(x);
                }
            }
        }

        var activeBeamColumns = new HashSet<int> { startPosition.Column };
        long splitterCount = 0;

        for (int row = startPosition.Row + 1; row < totalRows; row++)
        {
            var nextBeamColumns = new HashSet<int>();

            foreach (var column in activeBeamColumns)
            {
                var hitsSplitter = splittersByRow[row].Contains(column);

                if (hitsSplitter)
                {
                    splitterCount++;

                    if (column - 1 >= 0)
                    {
                        nextBeamColumns.Add(column - 1);
                    }

                    if (column + 1 < totalColumns)
                    {
                        nextBeamColumns.Add(column + 1);
                    }
                }
                else
                {
                    nextBeamColumns.Add(column);
                }

                activeBeamColumns = nextBeamColumns;

                if (activeBeamColumns.Count == 0)
                {
                    break;
                }
            }
        }

        return splitterCount;
    }

    public override object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}

