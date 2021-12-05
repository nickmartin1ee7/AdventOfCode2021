using Challanges;
using NUnit.Framework;
using System;
using Tests.Challanges;

namespace Tests.UnitTests;

public class Day2Tests
{
    private Day<int> _day;

    [SetUp]
    public void Setup()
    {
        _day = new Day2();
    }

    [Test]
    public void Part1()
    {
        var result = _day.Part1();
        Console.Write(result);
        Assert.AreEqual(1604850, result);
    }

    [Test]
    public void Part2()
    {
        var result = _day.Part2();
        Console.Write(result);
        Assert.AreEqual(1685186100, result);
    }
}
