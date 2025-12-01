using AdventOfCode.Core.Classes;
using AdventOfCode.Core.Extensions;

namespace AdventOfCode.Challenges;

public class Day01 : SolutionBase
{
    public override int Day => 01;

    public override object PartOne(string[] input)
    {
        var position = 50;
        var zeroCount = 0;

        foreach (var rotation in input)
        {
            var direction = rotation[0];
            var amount = int.Parse(rotation[1..]);

            var delta = direction == 'R' ? amount : -amount;

            position = (position + delta).PositiveMod(100);

            if (position == 0)
            {
                zeroCount += 1;
            }
        }

        return zeroCount;
    }

    public override object PartTwo(string[] input)
    {
        var position = 50;
        var zeroCount = 0;

        foreach (var rotation in input)
        {
            var direction = rotation[0];
            var amount = int.Parse(rotation[1..]);

            var delta = direction == 'R' ? amount : -amount;

            var start = position;
            var end = position + delta;

            var passes =
                direction == 'R'
                    ? end.FloorDiv(100) - start.FloorDiv(100)
                    : (start - 1).FloorDiv(100) - (end - 1).FloorDiv(100);

            zeroCount += passes;

            position = (position + delta).PositiveMod(100);
        }

        return zeroCount;
    }
}
