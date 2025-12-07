using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day06Test
{
    private Day06 _day06;

    private readonly string[] input =
    [
        "123 328  51 64",
        " 45 64  387 23",
        "  6 98  215 314",
        "*   +   *   +  "
    ];

    [SetUp]
    public void Setup()
    {
        _day06 = new Day06();
    }

    [Test]
    public void Example_Part1_ShouldReturn4277556()
    {
        // act
        var result = _day06.PartOne(input);

        // assert
        Assert.That((long)result, Is.EqualTo((long)4277556));
    }

    [Test]
    public void Example_Part2_ShouldReturn3263827()
    {
        // act
        var result = _day06.PartTwo(input);

        // assert
        Assert.That((long)result, Is.EqualTo((long)3263827));
    }
}
