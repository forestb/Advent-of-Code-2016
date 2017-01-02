using Common;

namespace Day13.Extensions
{
    public static class PointExtensions
    {
        public static bool IsValid(this Point p)
        {
            return p.X >= 0 && p.Y >= 0;
        }
    }
}
