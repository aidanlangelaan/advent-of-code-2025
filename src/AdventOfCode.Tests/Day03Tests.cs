using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day03Test
{
    private Day03 _day03;

    private readonly string[] input =
    [
        "987654321111111",
        "811111111111119",
        "234234234234278",
        "818181911112111"
    ];

    [SetUp]
    public void Setup()
    {
        _day03 = new Day03();
    }

    [Test]
    public void Example_Part1_ShouldReturn357()
    {
        // act
        var result = _day03.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(357));
    }

    [Test]
    public void Example_Part2_ShouldReturn123()
    {
        // act
        var result = _day03.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(123));
    }
}

