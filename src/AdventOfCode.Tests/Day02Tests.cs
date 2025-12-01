using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day02Test
{
    private Day02 _day02;

    private readonly string[] input =
    [
        "testvalue"
    ];

    [SetUp]
    public void Setup()
    {
        _day02 = new Day02();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn123()
    {
        // act
        var result = _day02.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(123));
    }

    [Test]
    public void Example_Part2_ShouldReturn123()
    {
        // act
        var result = _day02.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(123));
    }
}

