using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC2020
{
    public class Day7
    {
        private static Dictionary<string, Dictionary<string, int>> ParseInput()
        {
            return ParseGraph(File.ReadAllLines("./inputs/day7.txt"));
        }

        private static Dictionary<string, Dictionary<string, int>> ParseGraph(string[] lines)
        {
            var bagsGraph = new Dictionary<string, Dictionary<string, int>>();
            foreach (var line in lines)
            {
                var splitLine = line.Split("bags contain", StringSplitOptions.TrimEntries);
                var parentBag = splitLine[0];

                if (!bagsGraph.ContainsKey(parentBag))
                {
                    bagsGraph.Add(parentBag, new Dictionary<string, int>());
                }

                if (!char.IsDigit(splitLine[1][0]))
                {
                    continue;
                }

                var childBagsSegments = splitLine[1]
                    .Split(new[] {",", "bags", "bag", "."}, StringSplitOptions.TrimEntries);

                foreach (var segment in childBagsSegments)
                {
                    if (string.IsNullOrWhiteSpace(segment))
                    {
                        continue;
                    }

                    var count = segment.Split(' ')[0].Trim();
                    var colour = segment.Substring(count.Length).Trim();
                    bagsGraph[parentBag].Add(colour, int.Parse(count));
                }
            }

            return bagsGraph;
        }

        [Fact]
        public void Day7Task1Test()
        {
            Assert.Equal(4, ComputeTask1Output(ParseInput()));
        }

        private int ComputeTask1Output(Dictionary<string, Dictionary<string, int>> bagsGraph)
        {
            return bagsGraph.Keys.Count(key => CanContainColour(bagsGraph, "shiny gold", key));
        }

        private static bool CanContainColour(Dictionary<string, Dictionary<string, int>> bagsGraph, string colour,
            string currentColour,
            HashSet<string> visited = null)
        {
            return (visited ??= new HashSet<string>()).Add(currentColour) &&
                   (bagsGraph[currentColour].ContainsKey(colour) || bagsGraph[currentColour]
                       .Where(kvp => !visited.Contains(kvp.Key))
                       .Any(kvp => CanContainColour(bagsGraph, colour, kvp.Key, visited)));
        }

        [Fact]
        public void Day7Task2Test()
        {
            Assert.Equal(32, ComputeTask2Output(ParseInput()));
        }

        private int ComputeTask2Output(Dictionary<string, Dictionary<string, int>> bagsGraph)
        {
            return CountChildBags(bagsGraph, "shiny gold");
        }

        private static int CountChildBags(Dictionary<string, Dictionary<string, int>> bagsGraph, string colour,
            Dictionary<string, int> visited = null)
        {
            return (visited ??= new Dictionary<string, int>()).TryGetValue(colour, out int result)
                ? result
                : visited[colour] = bagsGraph[colour]
                    .Select(bc => bc.Value
                                  + bc.Value
                                  * CountChildBags(bagsGraph, bc.Key, visited))
                    .Sum();
        }
    }
}
