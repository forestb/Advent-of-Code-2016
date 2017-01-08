using System;

namespace Day20.Classes
{
    public class IpRangeSets
    {
        public Int64 RangeStart { get; set; }
        public Int64 RangeEnd { get; set; }

        public IpRangeSets(string rangeString)
        {
            string[] results = rangeString.Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries);

            RangeStart = Int64.Parse(results[0]);
            RangeEnd = Int64.Parse(results[1]);
        }

        public override string ToString()
        {
            return string.Concat(RangeStart, "-", RangeEnd);
        }
    }
}
