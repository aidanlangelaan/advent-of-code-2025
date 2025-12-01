using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day01Test
{
    private Day01 _day01;

    private readonly string[] input =
    [
        "L68",
        "L30",
        "R48",
        "L5 ",
        "R60",
        "L55",
        "L1 ",
        "L99",
        "R14",
        "L82"
    ];

    [SetUp]
    public void Setup()
    {
        _day01 = new Day01();
    }

    [Test]
    public void Example_Part1_ShouldReturn3()
    {
        // act
        var result = _day01.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Example_Part2_ShouldReturn6()
    {
        // act
        var result = _day01.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(6));
    }
}
