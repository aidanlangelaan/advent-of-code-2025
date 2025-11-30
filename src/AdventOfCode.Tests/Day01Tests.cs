using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day01Test
{
    private Day01 _day01;

    private readonly string[] input =
    [
        "testvalue"
    ];

    [SetUp]
    public void Setup()
    {
        _day01 = new Day01();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn123()
    {
        // act
        var result = _day01.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(123));
    }

    [Test]
    public void Example_Part2_ShouldReturn123()
    {
        // act
        var result = _day01.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(123));
    }
}

