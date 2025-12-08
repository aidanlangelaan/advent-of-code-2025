using System.Numerics;
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

        var startPosition = GetStartPosition(grid);
        var splittersByRow = GetSplittersByRow(totalRows, totalColumns, grid);

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
            }

            activeBeamColumns = nextBeamColumns;

            if (activeBeamColumns.Count == 0)
            {
                break;
            }
        }

        return splitterCount;
    }

    public override object PartTwo(string[] input)
    {
        var grid = GridHelper.ParseCharGrid(input);
        int totalRows = grid.Length;
        int totalColumns = grid[0].Length;

        var startPosition = GetStartPosition(grid);
        var splittersByRow = GetSplittersByRow(totalRows, totalColumns, grid);

        var timelinesInRow = new BigInteger[totalColumns];
        timelinesInRow[startPosition.Column] = 1;

        for (int row = startPosition.Row + 1; row < totalRows; row++)
        {
            var nextRowTimelines = new BigInteger[totalColumns];

            for (int col = 0; col < totalColumns; col++)
            {
                var count = timelinesInRow[col];
                if (count == 0)
                {
                    continue;
                }

                if (splittersByRow[row].Contains(col))
                {
                    if (col - 1 >= 0)
                    {
                        nextRowTimelines[col - 1] += count;
                    }

                    if (col + 1 < totalColumns)
                    {
                        nextRowTimelines[col + 1] += count;
                    }
                }
                else
                {
                    nextRowTimelines[col] += count;
                }
            }

            timelinesInRow = nextRowTimelines;
        }

        BigInteger totalTimelines = 0;
        for (int col = 0; col < totalColumns; col++)
        {
            totalTimelines += timelinesInRow[col];
        }

        return totalTimelines;
    }

    private static HashSet<int>[] GetSplittersByRow(int totalRows, int totalColumns, char[][] grid)
    {
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

        return splittersByRow;
    }

    private static (int Column, int Row) GetStartPosition(char[][] grid)
        => grid
            .SelectMany((row, y) => row.Select((cell, x) => (cell, x, y)))
            .Where(c => c.cell == 'S')
            .Select(c => (Column: c.x, Row: c.y))
            .First();
}
