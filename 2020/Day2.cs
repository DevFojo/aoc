using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC2020
{
    public class Day2
    {
        private static string[] ParseInput()
        {
            return File.ReadAllLines("./inputs/day2.txt");
        }

        [Fact]
        public void Day2Task1Test()
        {
            Assert.Equal(2, ComputeTask1Output(ParseInput()));
        }

        private int ComputeTask1Output(string[] passwordInputs)
        {
            var validPasswordCount = 0;
            foreach (var passwordInput in passwordInputs)
            {
                var passwordSegments = passwordInput.Split(new[]
                {
                    '-', ' ', ':'
                }, StringSplitOptions.RemoveEmptyEntries);
                var password = passwordSegments[3];
                var policyChar = passwordSegments[2][0];
                var policyCharCount = password.Count(c => c == policyChar);

                if (policyCharCount >= Convert.ToInt32(passwordSegments[0]) &&
                    policyCharCount <= Convert.ToInt32(passwordSegments[1]))
                {
                    validPasswordCount++;
                }
            }

            return validPasswordCount;
        }

        [Fact]
        public void Day2Task2Test()
        {
            Assert.Equal(1, ComputeTask2Output(ParseInput()));
        }

        private int ComputeTask2Output(string[] passwordInputs)
        {
            var validPasswordCount = 0;
            foreach (var passwordInput in passwordInputs)
            {
                var passwordSegments = passwordInput.Split(new[]
                {
                    '-', ' ', ':'
                }, StringSplitOptions.RemoveEmptyEntries);
                var password = passwordSegments[3];
                var policyChar = passwordSegments[2][0];

                var i = Convert.ToInt32(passwordSegments[0]) - 1;
                var j = Convert.ToInt32(passwordSegments[1]) - 1;
                if (policyChar != password[i] && policyChar != password[j] ||
                    policyChar == password[i] && policyChar == password[j])
                {
                    continue;
                }

                validPasswordCount++;
            }

            return validPasswordCount;
        }
    }
}
