using System;
using Day19.Classes;

namespace Day19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Sample Data
            //for (int i = 1; i <= 13; i++)
            //{
            //    PuzzleProcessor.Process(i);
            //}

            // Live Data
            PuzzleProcessor.Process(3001330);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
