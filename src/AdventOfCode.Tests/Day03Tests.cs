using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day03Test
{
    private Day03 _day03;

    private readonly string[] input =
    [
        "testvalue"
    ];

    [SetUp]
    public void Setup()
    {
        _day03 = new Day03();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn123()
    {
        // act
        var result = _day03.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(123));
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

