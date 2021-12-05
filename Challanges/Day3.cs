using BenchmarkDotNet.Attributes;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Challanges;

[MemoryDiagnoser]
public class Day3 : Day<int>
{
    string[] linesPart1;
    string[] linesPart2;

    public Day3()
    {
        linesPart1 = File.ReadAllLines("day3part1.txt");
        linesPart2 = File.ReadAllLines("day3part2.txt");
    }

    [Benchmark]
    public override int Part1()
    {
        static void CountTotals(string[] lines, int[] totals)
        {
            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    totals[i] += int.Parse($"{line[i]}");
                }
            }
        }

        static string GetMostCommon(int[] totals)
        {
            var binarySb = new StringBuilder();

            for (int i = 0; i < totals.Length; i++)
            {
                binarySb.Append(totals[i] switch
                {
                    >= 500 => 1,
                    < 500 => 0
                });
            }

            return binarySb.ToString();
        }

        static string GetLeastCommon(string mostCommon)
        {
            var binarySb = new StringBuilder();

            for (int i = 0; i < mostCommon.Length; i++)
            {
                binarySb.Append(mostCommon[i] switch
                {
                    '1' => 0,
                    '0' => 1
                });
            }

            return binarySb.ToString();
        }

        var totals = new int[12];
        CountTotals(linesPart1, totals);

        string gammaRate = GetMostCommon(totals),
            epsilonRate = GetLeastCommon(gammaRate);

        return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
    }

    [Benchmark]
    public override int Part2()
    {

        var o2List = linesPart2.ToArray();
        var co2List = linesPart2.ToArray();

        bool o2Ready = false;
        bool co2Ready = false;
        int i = 0;

        while (!o2Ready || !co2Ready)
        {
            if (o2List.Length != 1)
                o2List = GetListOfMostCommonAtIndex(o2List, i);
            else
                o2Ready = true;

            if (co2List.Length != 1)
                co2List = GetListOfLeastCommonAtIndex(co2List, i);
            else
                co2Ready = true;

            i++;
        }

        var o2Rate = o2List.First();
        var co2Rate = co2List.First();

        return Convert.ToInt32(o2Rate, 2) * Convert.ToInt32(co2Rate, 2);

        static string[] GetListOfMostCommonAtIndex(string[] lines, int i)
        {
            int one = 0;
            int zero = 0;

            foreach (var line in lines)
            {
                if (line[i] == '1')
                    one++;
                else if (line[i] == '0')
                    zero++;
            }

            char mostCommon = one >= zero ? '1' : '0';

            return lines.Where(l => l[i] == mostCommon).ToArray();
        }

        static string[] GetListOfLeastCommonAtIndex(string[] lines, int i)
        {
            int one = 0;
            int zero = 0;

            foreach (var line in lines)
            {
                if (line[i] == '1')
                    one++;
                else if (line[i] == '0')
                    zero++;
            }

            char leastCommon = one >= zero ? '0' : '1';

            return lines.Where(l => l[i] == leastCommon).ToArray();
        }
    }
}
