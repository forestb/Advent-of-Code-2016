using System;
using System.Collections.Generic;
using System.Linq;

namespace Day20.Classes
{
    public class PuzzleProcessor
    {
        public static void Process_Part1(string puzzleInput, Int64 maxValidValue)
        {
            // Parse the input
            List<IpRangeSet> ipRangeSets = new List<IpRangeSet>();

            foreach (string s in ParsedPuzzleInput(puzzleInput))
            {
                ipRangeSets.Add(new IpRangeSet(s));
            }

            var orderedIpRanges = ipRangeSets.OrderBy(x => x.RangeStart).ToList();

            for (int i = 0; i < orderedIpRanges.Count; i++)
            {
                int next = i + 1;

                Int64 currentLast = orderedIpRanges[i].RangeEnd;
                Int64 nextStart = (next >= orderedIpRanges.Count) ? maxValidValue : orderedIpRanges[next].RangeStart;
                Int64 difference = nextStart - currentLast;

                if (difference > 1)
                {
                    // We've found the first IP not blocked
                    Console.WriteLine($"{currentLast + 1} is not blocked. This was found in pair {i}.");
                    return;
                }
            }
        }

        public static void Process_Part2(string puzzleInput, Int64 maxValidValue)
        {
            // Parse the input
            List<IpRangeSet> ipRangeSets = new List<IpRangeSet>();

            foreach (string s in ParsedPuzzleInput(puzzleInput))
            {
                ipRangeSets.Add(new IpRangeSet(s));
            }

            PuzzleCalculator puzzleCalculate = new PuzzleCalculator(ipRangeSets, maxValidValue);

            Console.WriteLine($"There are {puzzleCalculate.SitesAllowedCount} values allowed.");
        }

        private static string[] ParsedPuzzleInput(string puzzleInput) =>
            puzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }
}
