namespace AdventOfCode.Core.Helpers;

public static class GridHelper
{
    /// <summary>
    /// Parse a string[] into a jagged grid using a per-character mapper.
    /// </summary>
    public static T[][] ParseGrid<T>(string[] input, Func<char, T> map)
        => input.Select(line => line.Select(map).ToArray()).ToArray();

    /// <summary>
    /// Char grid: each line -> char[]
    /// </summary>
    public static char[][] ParseCharGrid(string[] input)
        => ParseGrid(input, c => c);

    /// <summary>
    /// Digit grid: '0'..'9' -> int. Throws on non-digits.
    /// </summary>
    public static int[][] ParseDigitGrid(string[] input)
        => ParseGrid(input, c => c is >= '0' and <= '9'
            ? c - '0'
            : throw new FormatException($"Non-digit '{c}' in input."));

    /// <summary>
    /// Token-based grid: splits each line by separator, maps tokens to T.
    /// Usefull if cells are multi-digit or text.
    /// </summary>
    public static T[][] ParseTokenGrid<T>(string[] input, Func<string, T> map, char separator = ' ')
        => input.Select(line => line.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(map)
                .ToArray())
            .ToArray();

    /// <summary>
    /// Neighbours in 4 directions (N,E,S,W). Only returns in-bounds coords.
    /// </summary>
    public  static List<(int x, int y)> GetNeighboursForIndex4(int x, int y, char[][] grid)
    {
        ReadOnlySpan<(int dx, int dy)> dirs =
        [
            (0, -1), // N
            (1,  0), // E
            (0,  1), // S
            (-1, 0) // W
        ];

        var result = new List<(int x, int y)>(4);

        for (var i = 0; i < dirs.Length; i++)
        {
            var nx = x + dirs[i].dx;
            var ny = y + dirs[i].dy;

            if (ny < 0 || ny >= grid.Length) continue;
            var row = grid[ny];
            if (nx < 0 || nx >= row.Length) continue;

            result.Add((nx, ny));
        }

        return result;
    }

    /// <summary>
    /// Neighbours in 8 directions (including. diagonals). Only returns in-bounds coords.
    /// </summary>
    public static List<(int x, int y)> GetNeighboursForIndex8(char[][] grid, int x, int y)
    {
        ReadOnlySpan<(int dx, int dy)> dirs =
        [
            (0, -1), (1, -1), (1, 0), (1, 1),
            (0,  1), (-1, 1), (-1, 0), (-1, -1)
        ];

        var result = new List<(int x, int y)>(8);

        for (var i = 0; i < dirs.Length; i++)
        {
            var nx = x + dirs[i].dx;
            var ny = y + dirs[i].dy;

            if (ny < 0 || ny >= grid.Length) continue;
            var row = grid[ny];
            if (nx < 0 || nx >= row.Length) continue;

            result.Add((nx, ny));
        }

        return result;
    }

    public static bool InBounds<T>(int x, int y, T[][] grid)
        => y >= 0 && y < grid.Length && x >= 0 && x < grid[y].Length;
}
