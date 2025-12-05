using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day05Test
{
    private Day05 _day05;

    private readonly string[] input =
    [
        "3-5",
        "10-14",
        "16-20",
        "12-18",
        "",
        "1",
        "5",
        "8",
        "11",
        "17",
        "32"
    ];

    [SetUp]
    public void Setup()
    {
        _day05 = new Day05();
    }

    [Test]
    public void Example_Part1_ShouldReturn3()
    {
        // act
        var result = _day05.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Example_Part2_ShouldReturn123()
    {
        // act
        var result = _day05.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(123));
    }
}
