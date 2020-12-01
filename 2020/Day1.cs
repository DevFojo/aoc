using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2020
{
    public class Day1
    {
        private static int[] ParseInput()
        {
            var lines = File.ReadAllLines("./inputs/day1.txt");
            return lines.Select(i => Convert.ToInt32(i)).ToArray();
        }

        [Fact]
        public void Day1Task1Test()
        {
            Assert.Equal(514579, ComputeTask1Output(ParseInput()));
        }

        private static int ComputeTask1Output(params int[] input)
        {
            var set = new HashSet<int>();
            foreach (var x in input)
            {
                set.Add(x);
            }

            foreach (var i in set)
            {
                var diff = 2020 - i;
                if (set.Contains(diff))
                {
                    return diff * i;
                }
            }

            return -1;
        }

        [Fact]
        public void Day1Task2Test()
        {
            Assert.Equal(241861950, ComputeTask2Output(ParseInput()));
        }

        private long ComputeTask2Output(params int[] input)
        {
            var set = new HashSet<int>();
            foreach (var x in input)
            {
                set.Add(x);
            }

            var i = 0;
            while (i < input.Length - 2)
            {
                var j = i + 1;
                var diff = 2020 - input[i];
                set.Remove(input[i]);
                while (j < input.Length)
                {
                    var diff2 = diff - input[j];
                    set.Remove(input[j]);
                    if (set.Contains(diff2))
                    {
                        return diff2 * input[j] * input[i];
                    }

                    set.Add(input[j]);
                    j++;
                }

                set.Add(input[i]);
                i++;
            }


            return 0;
        }

        [Fact]
        public void Day1Task2Test2()
        {
            Assert.Equal(241861950, ComputeTask2OutputV2(ParseInput()));
        }
        
        private long ComputeTask2OutputV2(params int[] input)
        {
            Array.Sort(input);
            for (var i = 0; i < input.Length; i++)
            {
                if (i > 0 && input[i] == input[i - 1])
                {
                    continue;
                }

                var j = i + 1;
                var k = input.Length - 1;

                var diff1 = 2020 - input[i];
                while (j < k)
                {
                    var sum = input[j] + input[k];
                    if (sum == diff1)
                    {
                        return input[j] * input[k] * input[i];
                    }

                    if (sum > diff1)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return 0;
        }
    }
}
