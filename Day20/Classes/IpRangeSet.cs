using System;

namespace Day20.Classes
{
    public class IpRangeSet
    {
        public Int64 RangeStart { get; set; }
        public Int64 RangeEnd { get; set; }

        public IpRangeSet()
        {
            
        }

        public IpRangeSet(string rangeString)
        {
            string[] results = rangeString.Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries);

            RangeStart = Int64.Parse(results[0]);
            RangeEnd = Int64.Parse(results[1]);
        }

        public override string ToString()
        {
            return string.Concat(RangeStart, "-", RangeEnd);
        }

        public override bool Equals(object obj)
        {
            if (obj is IpRangeSet)
            {
                return RangeStart == ((IpRangeSet) obj).RangeStart && RangeEnd == ((IpRangeSet) obj).RangeEnd;
            }

            return base.Equals(obj);
        }

        public static bool operator ==(IpRangeSet a, IpRangeSet b)
        {
            return a?.RangeStart == b?.RangeStart && a?.RangeEnd == b?.RangeEnd;
        }

        public static bool operator !=(IpRangeSet a, IpRangeSet b)
        {
            return !(a == b);
        }
    }
}
