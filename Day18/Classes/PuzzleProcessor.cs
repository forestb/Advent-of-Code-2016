using System;

namespace Day18.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(PuzzleData pd)
        {
            // Process all the tiles on the floor
            Floor f = new Floor(pd.PuzzleInput, pd.RowCount);

            // Print it out
            f.Print();
            Console.WriteLine($"There are {f.SafeTileCount} safe tiles.");
        }
    }
}
