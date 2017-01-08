using System;
using System.Collections.Generic;
using System.Linq;

namespace Day20.Classes
{
    public class PuzzleCalculator
    {
        public List<IpRangeSet> IpRangeSets { get; set; }
        public long MaxValidValue { get; }

        public PuzzleCalculator(List<IpRangeSet> ipRangeSets, Int64 maxValidValue)
        {
            IpRangeSets = ipRangeSets;
            MaxValidValue = maxValidValue;
        }

        public Int64 SitesAllowedCount => CalculateSitesAllowedCount();
        
        private Int64 CalculateSitesAllowedCount()
        {
            Int64 maxAllowedRange = MaxValidValue + 1;  // e.g. since min/max is inclusive, 0 - 100 has 102 valid values

            Queue<IpRangeSet> ipRangeQueue = null;
            List<IpRangeSet> listToTraverse = null;

            // Traverse by RangeStart, Forwards
            ipRangeQueue = new Queue<IpRangeSet>(IpRangeSets.OrderBy(x => x.RangeStart));
            listToTraverse = new List<IpRangeSet>();
            TraverseList(ipRangeQueue, listToTraverse);

            // Traverse by RangeStart, Backwards
            ipRangeQueue = new Queue<IpRangeSet>(listToTraverse.OrderByDescending(x => x.RangeStart));
            listToTraverse = new List<IpRangeSet>();
            TraverseList(ipRangeQueue, listToTraverse);

            // Traverse by RangeEnd, Forwards
            ipRangeQueue = new Queue<IpRangeSet>(listToTraverse.OrderBy(x => x.RangeEnd));
            listToTraverse = new List<IpRangeSet>();
            TraverseList(ipRangeQueue, listToTraverse);

            // Traverse by RangeEnd, Backwards
            ipRangeQueue = new Queue<IpRangeSet>(listToTraverse.OrderByDescending(x => x.RangeEnd));
            listToTraverse = new List<IpRangeSet>();
            TraverseList(ipRangeQueue, listToTraverse);

            // Print out the list
            //...listToTraverse.OrderBy(y => y.RangeStart).ToList().ForEach(x => Console.WriteLine($"{x.RangeStart}-{x.RangeEnd}"));

            // Sum up all the ranges
            Int64 sum = listToTraverse.Sum(x => (x.RangeEnd - x.RangeStart + 1));

            // Finished
            return maxAllowedRange - sum;
        }

        private void TraverseList(Queue<IpRangeSet> ipRangeQueue, List<IpRangeSet> listToTraverse)
        {
            while (ipRangeQueue.Count > 0)
            {
                IpRangeSet current = ipRangeQueue.Dequeue();

                if (listToTraverse.Count == 0)
                {
                    listToTraverse.Add(current);
                    continue;
                }

                // see if our list already has any of current node's values
                var lowerNode =
                    listToTraverse.FirstOrDefault(x => current.RangeStart >= x.RangeStart && current.RangeStart <= x.RangeEnd);

                var upperNode =
                    listToTraverse.FirstOrDefault(x => current.RangeEnd >= x.RangeStart && current.RangeEnd <= x.RangeEnd);

                // exit criteria
                if (lowerNode != null && upperNode != null)
                {
                    if (lowerNode == upperNode)
                    {
                        // The proposed range is already covered by a single node
                        continue;
                    }

                    // Assume the following scenario
                    // Existing nodes:
                    //   39-40, 41-50
                    // Add 40-50
                    // The node were adding is already covered within the list.
                    if (upperNode.RangeStart - lowerNode.RangeEnd <= 1)
                    {
                        continue;
                    }
                }

                // what *updated* range should be added to our list?
                IpRangeSet temp = new IpRangeSet()
                {
                    RangeStart = lowerNode == null ? current.RangeStart : lowerNode.RangeEnd + 1,
                    RangeEnd = upperNode == null ? current.RangeEnd : upperNode.RangeStart - 1
                };

                listToTraverse.Add(temp);
            }
        }
    }
}
