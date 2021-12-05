using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challanges;

[MemoryDiagnoser]
public class Day4 : Day<int>
{
    private string[] linesPart1;
    private string[] linesPart2;

    public Day4()
    {
        linesPart1 = File.ReadAllLines("day4part1.txt");
        linesPart2 = File.ReadAllLines("day4part1.txt");
    }

    private class Board
    {
        private bool hasWon = false;
        private readonly int xLen;
        private readonly int yLen;
        private readonly int[,] keys;
        private readonly bool[,] pickedKeys;

        public Board(int[,] keys)
        {
            this.keys = keys;
            yLen = keys.GetLength(0);
            xLen = keys.GetLength(1);
            pickedKeys = new bool[yLen, xLen];
        }

        public bool PickKey(int key)
        {
            if (hasWon) // Only win once!
                return false;

            for (int y = 0; y < keys.GetLength(0); y++)
            {
                for (int x = 0; x < keys.GetLength(1); x++)
                {
                    if (keys[y, x] == key)
                    {
                        pickedKeys[y, x] = true;
                        if (CheckForWin())
                        {
                            hasWon = true;
                        }
                    }
                }
            }

            return hasWon;
        }

        private bool CheckForWin()
        {
            bool CheckHorizontalWin()
            {
                int xCount = 0;

                for (int y = 0; y < yLen; y++)
                {
                    for (int x = 0; x < xLen; x++)
                    {
                        if (pickedKeys[y, x])
                        {
                            xCount++;
                        }
                    }

                    if (xCount == xLen)
                    {
                        return true; // Horizontal win
                    }
                    else
                    {
                        xCount = 0;
                    }
                }

                return false;
            }

            bool CheckVerticalWin()
            {
                int yCount = 0;

                for (int x = 0; x < xLen; x++)
                {
                    for (int y = 0; y < yLen; y++)
                    {
                        if (pickedKeys[y, x])
                        {
                            yCount++;
                        }
                    }

                    if (yCount == yLen)
                    {
                        return true; // Vertical win
                    }
                    else
                    {
                        yCount = 0;
                    }
                }

                return false;
            }

            if (CheckHorizontalWin() || CheckVerticalWin())
                return true;

            return false;
        }

        internal int CalculateScore(int lastCall)
        {
            int sum = 0;

            for (int y = 0; y < yLen; y++)
            {
                for (int x = 0; x < xLen; x++)
                {
                    if (!pickedKeys[y, x])
                    {
                        sum += keys[y, x];
                    }
                }
            }

            return sum * lastCall;
        }
    }

    [Benchmark]
    public override int Part1()
    {
        int[] picks = Array.Empty<int>();

        var boards = new List<Board>();
        var currentBoard = new int[5, 5];
        int y = 0;

        for (int i = 0; i < linesPart1.Length; i++)
        {
            if (i == 0)
            {
                picks = linesPart1[i].Split(',')
                    .Select(x => int.Parse(x))
                    .ToArray();
                continue;
            }
            else if (i == 1)
            {
                continue;
            }

            if (string.IsNullOrEmpty(linesPart1[i]))
            {
                boards.Add(new Board(currentBoard));
                currentBoard = new int[5, 5];
                y = 0;
            }
            else
            {
                var lineKeys = linesPart1[i].Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int j = 0; j < lineKeys.Length; j++)
                {
                    currentBoard[y, j] = lineKeys[j];
                }

                y++;
            }
        }

        foreach (var pick in picks)
        {
            foreach (var board in boards)
            {
                if (board.PickKey(pick))
                {
                    return board.CalculateScore(pick);
                }
            }
        }

        return 0;
    }

    [Benchmark]
    public override int Part2()
    {
        int[] picks = Array.Empty<int>();

        var boards = new List<Board>();
        var currentBoard = new int[5, 5];
        int y = 0;

        for (int i = 0; i < linesPart2.Length; i++)
        {
            if (i == 0)
            {
                picks = linesPart2[i].Split(',')
                    .Select(x => int.Parse(x))
                    .ToArray();
                continue;
            }
            else if (i == 1)
            {
                continue;
            }

            if (string.IsNullOrEmpty(linesPart2[i]))
            {
                boards.Add(new Board(currentBoard));
                currentBoard = new int[5, 5];
                y = 0;
            }
            else
            {
                var lineKeys = linesPart2[i].Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int j = 0; j < lineKeys.Length; j++)
                {
                    currentBoard[y, j] = lineKeys[j];
                }

                y++;
            }
        }

        var winningBoards = new List<(Board Board, int Score)>();

        foreach (var pick in picks)
        {
            foreach (var board in boards)
            {
                if (board.PickKey(pick))
                {
                    var score = board.CalculateScore(pick);
                    winningBoards.Add((board, score));
                }
            }
        }

        return winningBoards[^1].Score;
    }
}
