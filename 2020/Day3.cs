using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC2020
{
    public class Day3
    {
        private static string[] ParseInput()
        {
            return File.ReadAllLines("./inputs/day3.txt");
        }

        [Fact]
        public void Day3Task1Test()
        {
            Assert.Equal(7, ComputeTask1Output(ParseInput()));
        }

        private int ComputeTask1Output(string[] lines)
        {
            var treesCount = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var j = i * 3 % line.Length;
                if (line[j] == '#')
                {
                    treesCount++;
                }
            }

            return treesCount;
        }

        [Fact]
        public void Day3Task2Test()
        {
            Assert.Equal(336, ComputeTask2Output(ParseInput()));
        }

        private long ComputeTask2Output(string[] lines)
        {
            var directions = new (int x, int y)[] {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)};

            var nextIs = new[] {0, 0, 0, 0, 0};
            var nextJs = new[] {0, 0, 0, 0, 0};
            var treesCounts = new[] {0, 0, 0, 0, 0};
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var a = 0; a < directions.Length; a++)
                {
                    if (i != nextIs[a])
                    {
                        continue;
                    }

                    if (line[nextJs[a]] == '#')
                    {
                        treesCounts[a]++;
                    }

                    nextIs[a] = nextIs[a] + directions[a].y;
                    nextJs[a] = (nextJs[a] + directions[a].x) % line.Length;
                }
            }

            long treesCountsProduct = 1;
            for (var a = 0; a < directions.Length; a++)
            {
                treesCountsProduct *= treesCounts[a];
            }

            return treesCountsProduct;
        }
    }
}
