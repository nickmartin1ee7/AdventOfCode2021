using Challanges;
using NUnit.Framework;
using System;
using Tests.Challanges;

namespace Tests.UnitTests;

public class Day3Tests
{
    private Day<int> _day;

    [SetUp]
    public void Setup()
    {
        _day = new Day3();
    }

    [Test]
    public void Part1()
    {
        var result = _day.Part1();
        Console.Write(result);
        Assert.AreEqual(3969000, result);
    }

    [Test]
    public void Part2()
    {
        var result = _day.Part2();
        Console.Write(result);
        Assert.AreEqual(4267809, result);
    }
}
