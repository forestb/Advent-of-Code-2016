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
            if (pd.RowCount < 100)
            {
                f.Print();
            }
            else
            {
                Console.WriteLine($"{pd.RowCount} are too many rows to print (visualize) the grid.  Skipping Print();");
            }
            
            Console.WriteLine($"There are {f.SafeTileCount} safe tiles.");
        }
    }
}
