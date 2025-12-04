using System.Numerics;
using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day03 : SolutionBase
{
    public override int Day => 03;

    public override object PartOne(string[] input)
    {
        var highestValues = input
            .Select(bank => BuildMaximumJoltage(bank, 2))
            .ToList();

        return highestValues.Aggregate(BigInteger.Zero, (acc, value) => acc + value);
    }

    public override object PartTwo(string[] input)
    {
        var highestValues = input
            .Select(bank => BuildMaximumJoltage(bank, 12))
            .ToList();

        return highestValues.Aggregate(BigInteger.Zero, (acc, value) => acc + value);
    }

    private static BigInteger BuildMaximumJoltage(string bankDigits, int digitsToSelect)
    {
        var maxSequence = BuildMaxDigitSubsequence(bankDigits, digitsToSelect);
        return BigInteger.Parse(maxSequence);
    }

    private static string BuildMaxDigitSubsequence(string bankDigits, int digitsToSelect)
    {
        int digitsToDrop = bankDigits.Length - digitsToSelect;
        var digitStack = new List<char>(bankDigits.Length);

        foreach (char digit in bankDigits)
        {
            while (digitsToDrop > 0 &&
                   digitStack.Count > 0 &&
                   digitStack[^1] < digit)
            {
                digitStack.RemoveAt(digitStack.Count - 1);
                digitsToDrop--;
            }

            digitStack.Add(digit);
        }

        if (digitStack.Count > digitsToSelect)
        {
            digitStack.RemoveRange(digitsToSelect, digitStack.Count - digitsToSelect);
        }

        return new string(digitStack.ToArray());
    }
}
