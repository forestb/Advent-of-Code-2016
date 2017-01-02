namespace Day13.Classes
{
    public enum CoordinateType
    {
        OPEN_SPACE = 0,
        WALL
    }

    public class CoordinateCalculator
    {
        private static uint ArbitraryEquation(uint x, uint y)
        {
            return x*x + 3*x + 2*x*y + y + y*y;
        }

        // retrieved from http://articles.leetcode.com/number-of-1-bits/
        private static uint CountNumberOfOnes(uint x)
        {
            uint totalOnes = 0;

            while (x != 0)
            {
                x = x & (x - 1);
                totalOnes++;
            }

            return totalOnes;
        }

        public static uint GetCoordinateType(uint x, uint y, uint favoriteNumber)
        {
            // Find x*x + 3*x + 2*x*y + y + y*y.
            // Add the office designer's favorite number (your puzzle input).
            uint sum = ArbitraryEquation(x, y) + favoriteNumber;

            /* Find the binary representation of that sum; count the number of bits that are 1.
             * If the number of bits that are 1 is even, it's an open space.
             * If the number of bits that are 1 is odd, it's a wall.*/
            uint numberOfOnes = CountNumberOfOnes(sum);

            // Finished
            return (numberOfOnes % 2 == 0) ? (uint) CoordinateType.OPEN_SPACE : (uint) CoordinateType.WALL;
        }
    }
}
