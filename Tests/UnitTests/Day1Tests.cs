using Challanges;
using NUnit.Framework;
using System;

namespace Tests.UnitTests;

public class Day1Tests
{
    private Day<int> _day;

    [SetUp]
    public void Setup()
    {
        _day = new Day1();
    }

    [Test]
    public void Part1()
    {
        var result = _day.Part1();
        Console.Write(result);
        Assert.AreEqual(1713, result);
    }

    [Test]
    public void Part2()
    {
        var result = _day.Part2();
        Console.Write(result);
        Assert.AreEqual(1734, result);
    }
}
