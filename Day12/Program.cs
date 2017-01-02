using System;
using Common;
using Day12.Classes;

namespace Day12
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInputSample => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");

        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Sample
            //string[] parsedPuzzleInputSample = PuzzleInputSample.Split(new[] {Environment.NewLine},
            //    StringSplitOptions.RemoveEmptyEntries);

            //PuzzleProcessor.Process(parsedPuzzleInputSample);

            // Part 1
            string[] parsedPuzzleInput = PuzzleInput.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            PuzzleProcessor.Process(parsedPuzzleInput);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds/1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
