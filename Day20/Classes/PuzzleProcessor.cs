using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day20.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(string puzzleInput)
        {
            // Parse the input
            List<IpRangeSets> ipRangeSets = new List<IpRangeSets>();

            string[] parsedPuzzleInput = puzzleInput.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in parsedPuzzleInput)
            {
                ipRangeSets.Add(new IpRangeSets(s));
            }

            // Print the IP address range
            // ipRangeSets.ForEach(x => Console.WriteLine($"{x.RangeStart} to {x.RangeEnd}"));

            // Determine the lowest valued IP which is not blocked
            Int64 min = 0;
            Int64 max = 4294967295;

            var orderedIpRanges = ipRangeSets.OrderBy(x => x.RangeStart).ToList();

            for (int i = 0; i < orderedIpRanges.Count; i++)
            {
                Int64 currentLast = orderedIpRanges[i].RangeEnd;
                Int64 nextStart = orderedIpRanges[i+1].RangeStart;

                Int64 difference = nextStart - currentLast;

                if (difference > 1)
                {
                    // We've found the first IP not blocked
                    Console.WriteLine($"{currentLast + 1} is not blocked. This was found in pair {i}.");
                    return;
                }
            }
        }
    }
}
