using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challanges;

[MemoryDiagnoser]
public class Day1 : Day<int>
{
    int[] numbersPart1;
    int[] numbersPart2;

    public Day1()
    {
        numbersPart1 = File.ReadAllLines("day1part1.txt")
            .Select(line => int.Parse(line))
            .ToArray();

        numbersPart2 = File.ReadAllLines("day1part2.txt")
            .Select(line => int.Parse(line))
            .ToArray();
    }

    [Benchmark]
    public override int Part1()
    {
        int increaseCount = 0;

        for (int i = 1; i < numbersPart1.Length; i++)
        {
            int previous = numbersPart1[i - 1];
            int current = numbersPart1[i];
            if (current > previous) increaseCount++;
        }

        return increaseCount;
    }

    [Benchmark]
    public override int Part2()
    {
        int increaseCount = 0;

        var sums = new List<int>();

        for (int i = 1; i < numbersPart2.Length - 1; i++)
        {
            int previous = numbersPart2[i - 1];
            int current = numbersPart2[i];
            int next = numbersPart2[i + 1];

            int sum = previous + current + next;

            if (sums.Count != 0 && sum > sums[^1])
            {
                increaseCount++;
            }

            sums.Add(sum);
        }

        return increaseCount;
    }
}
