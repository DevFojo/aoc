using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace AOC2020
{
    public class Day5
    {
        private static string[] ParseInput()
        {
            return File.ReadAllLines("./inputs/day5.txt");
        }

        [Fact]
        public void Day5Task1Test()
        {
            Assert.Equal(820, ComputeTask1Output(ParseInput()));
        }

        private int ComputeTask1Output(string[] lines)
        {
            var max = 0;
            foreach (var line in lines)
            {
                var row = 0;
                var column = 0;
                for (var i = 0; i < line.Length; i++)
                {
                    if (i < 7 && line[i] == 'B')
                    {
                        row += 1 << (6 - i);
                    }

                    if (i >= 7 && line[i] == 'R')
                    {
                        column += 1 << (9 - i);
                    }
                }

                var seatId = row * 8 + column;
                max = Math.Max(max, seatId);
            }

            return max;
        }

        [Fact]
        public void Day5Task2Test()
        {
            Assert.Equal(0, ComputeTask2Output(ParseInput()));
        }

        private int ComputeTask2Output(string[] lines)
        {
            var seats = new SortedSet<int>();
            for (var i = 0; i < 128 * 8; i++)
            {
                seats.Add(i);
            }

            foreach (var line in lines)
            {
                var row = 0;
                var column = 0;
                for (var i = 0; i < line.Length; i++)
                {
                    if (i < 7 && line[i] == 'B')
                    {
                        row += 1 << (6 - i);
                    }

                    if (i >= 7 && line[i] == 'R')
                    {
                        column += 1 << (9 - i);
                    }
                }

                var seatId = row * 8 + column;
                seats.Remove(seatId);
            }

            return 0;
        }
    }
}
