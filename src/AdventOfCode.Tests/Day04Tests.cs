using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day04Test
{
    private Day04 _day04;

    private readonly string[] input =
    [
        "..@@.@@@@.",
        "@@@.@.@.@@",
        "@@@@@.@.@@",
        "@.@@@@..@.",
        "@@.@@@@.@@",
        ".@@@@@@@.@",
        ".@.@.@.@@@",
        "@.@@@.@@@@",
        ".@@@@@@@@.",
        "@.@.@@@.@."
    ];

    [SetUp]
    public void Setup()
    {
        _day04 = new Day04();
    }

    [Test]
    public void Example_Part1_ShouldReturn13()
    {
        // act
        var result = _day04.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(13));
    }

    [Test]
    public void Example_Part2_ShouldReturn43()
    {
        // act
        var result = _day04.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(43));
    }
}
