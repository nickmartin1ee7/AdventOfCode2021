using Challanges;
using NUnit.Framework;
using System;
using Tests.Challanges;

namespace Tests.UnitTests;

public class Day4Tests
{
    private Day<int> _day;

    [SetUp]
    public void Setup()
    {
        _day = new Day4();
    }

    [Test]
    public void Part1()
    {
        var result = _day.Part1();
        Console.Write(result);
        Assert.AreEqual(41668, result);
    }

    [Test]
    public void Part2()
    {
        var result = _day.Part2();
        Console.Write(result);
        Assert.AreEqual(10478, result);
    }
}

//Assert.Inconclusive();