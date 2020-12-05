using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace AOC2020
{
    public class Day4
    {
        private static string[] ParseInput()
        {
            var input = File.ReadAllText("./inputs/day4.txt");
            return input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        }

        [Fact]
        public void Day4Task1Test()
        {
            Assert.Equal(2, ComputeTask1Output(ParseInput()));
        }

        private int ComputeTask1Output(string[] lines)
        {
            var validCount = 0;
            foreach (var line in lines)
            {
                var requiredFields = new HashSet<string> {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
                var fields = Regex.Split(line, "\\s");
                
                foreach (var field in fields)
                {
                    var fieldKey = field.Substring(0, 3);
                    if (requiredFields.Contains(fieldKey))
                    {
                        requiredFields.Remove(fieldKey);
                    }
                }

                if (requiredFields.Count == 0)
                {
                    validCount++;
                }
            }

            return validCount;
        }

        [Fact]
        public void Day4Task2Test()
        {
            Assert.Equal(2, ComputeTask2Output(ParseInput()));
        }

        private int ComputeTask2Output(string[] lines)
        {
            var validCount = 0;
            foreach (var line in lines)
            {
                var requiredFields = new Dictionary<string, string>
                {
                    {"byr", "(19[2-9][0-9]|200[0-2])"},
                    {"iyr", "(201[0-9]|2020)"},
                    {"eyr", "(202[0-9]|2030)"},
                    {"hgt", "(1[5-8][0-9]|19[1-3])cm|(59|6[0-9]|7[0-6])in"},
                    {"hcl", "#[a-f\\d]{6}"},
                    {"ecl", "(amb|blu|brn|gry|grn|hzl|oth)"},
                    {"pid", "\\d{9}"}
                };
                var fields = Regex.Split(line, "\\s");

                if (fields.Length < requiredFields.Count)
                {
                    continue;
                }

                foreach (var field in fields)
                {
                    var fieldKey = field.Substring(0, 3);
                    if (requiredFields.ContainsKey(fieldKey) && new Regex(requiredFields[fieldKey]).IsMatch(field, 3))
                    {
                        requiredFields.Remove(fieldKey);
                    }
                }

                if (requiredFields.Count == 0)
                {
                    validCount++;
                }
            }

            return validCount;
        }
    }
}
