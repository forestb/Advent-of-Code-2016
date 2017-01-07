using System;

namespace Day18.Better.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(PuzzleData pd, bool shouldPrintResult = false)
        {
            Floor f = new Floor(pd.PuzzleInput, pd.RowCount);

            if (shouldPrintResult)
            {
                f.Print();
            }

            Console.WriteLine($"There are {f.SafeCount} safe tiles.");
        }
    }
}
