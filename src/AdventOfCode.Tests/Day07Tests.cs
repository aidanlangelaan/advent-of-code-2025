using System.Numerics;
using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day07Test
{
    private Day07 _day07;

    private readonly string[] input =
    [
        ".......S.......",
        "...............",
        ".......^.......",
        "...............",
        "......^.^......",
        "...............",
        ".....^.^.^.....",
        "...............",
        "....^.^...^....",
        "...............",
        "...^.^...^.^...",
        "...............",
        "..^...^.....^..",
        "...............",
        ".^.^.^.^.^...^.",
        "..............."
    ];

    [SetUp]
    public void Setup()
    {
        _day07 = new Day07();
    }

    [Test]
    public void Example_Part1_ShouldReturn21()
    {
        // act
        var result = _day07.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(21));
    }

    [Test]
    public void Example_Part2_ShouldReturn40()
    {
        // act
        var result = _day07.PartTwo(input);

        // assert
        Assert.That((BigInteger)result, Is.EqualTo((BigInteger)40));
    }
}
