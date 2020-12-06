using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC2020
{
    public class Day6
    {
        private static string[] ParseInput()
        {
            var input = File.ReadAllText("./inputs/day6.txt");
            return input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        }

        [Fact]
        public void Day6Task1Test()
        {
            Assert.Equal(11, ComputeTask1Output(ParseInput()));
        }

        private int ComputeTask1Output(string[] groupAnswers)
        {
            var count = 0;
            foreach (var answer in groupAnswers)
            {
                var answers = new HashSet<char>();
                foreach (var c in answer.Where(char.IsLetter))
                {
                    answers.Add(c);
                }

                count += answers.Count;
            }

            return count;
        }

        [Fact]
        public void Day6Task2Test()
        {
            Assert.Equal(6, ComputeTask2Output(ParseInput()));
        }

        private int ComputeTask2Output(string[] groupAnswers)
        {
            var count = 0;
            foreach (var answer in groupAnswers)
            {
                var s = answer.Trim();
                if (string.IsNullOrWhiteSpace(s))
                {
                    continue;
                }

                var answers = new Dictionary<char, int>();
                var groupSize = 1;
                foreach (var c in s)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        groupSize++;
                    }

                    if (!answers.ContainsKey(c))
                    {
                        answers[c] = 0;
                    }

                    answers[c]++;
                }

                foreach (var (c, i) in answers)
                {
                    if (i == groupSize)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
