using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day02Test
{
    private Day02 _day02;

    private readonly string[] input =
    [
        "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
    ];

    [SetUp]
    public void Setup()
    {
        _day02 = new Day02();
    }

    [Test]
    public void Example_Part1_ShouldReturn1227775554()
    {
        // act
        var result = _day02.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(1227775554));
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

