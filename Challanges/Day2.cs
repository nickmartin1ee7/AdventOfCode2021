using BenchmarkDotNet.Attributes;
using System.IO;
using System.Linq;

namespace Challanges;

[MemoryDiagnoser]
public class Day2 : Day<int>
{
    string[] linesPart1;
    string[] linesPart2;

    public Day2()
    {
        linesPart1 = File.ReadAllLines("day2part1.txt")
            .ToArray();

        linesPart2 = File.ReadAllLines("day2part2.txt")
            .ToArray();
    }

    [Benchmark]
    public override int Part1()
    {
        int horizontalPosition = 0,
            depth = 0;

        for (int i = 0; i < linesPart1.Length; i++)
        {
            var inLine = linesPart1[i];
            var instruction = inLine.Split(" ");
            var action = instruction[0];
            var amount = int.Parse(instruction[1]);

            switch (action)
            {
                case "forward":
                    horizontalPosition += amount;
                    break;
                case "up":
                    depth -= amount;
                    break;
                case "down":
                    depth += amount;
                    break;
            }
        }

        return horizontalPosition * depth;
    }

    [Benchmark]
    public override int Part2()
    {
        int horizontalPosition = 0,
            depth = 0,
            aim = 0;

        for (int i = 0; i < linesPart2.Length; i++)
        {
            var inLine = linesPart2[i];
            var instruction = inLine.Split(" ");
            var action = instruction[0];
            var amount = int.Parse(instruction[1]);

            switch (action)
            {
                case "forward":
                    horizontalPosition += amount;
                    depth += aim * amount;
                    break;
                case "up":
                    aim -= amount;
                    break;
                case "down":
                    aim += amount;
                    break;
            }
        }

        return horizontalPosition * depth;
    }
}
