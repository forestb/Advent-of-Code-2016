using System;
using Common;
using Day20.Classes;

namespace Day20
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInputSample => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");

        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Sample Puzzle Input, Part 1
            //PuzzleProcessor.Process(PuzzleInputSample);

            // Actual puzzle input, Part 1
            PuzzleProcessor.Process(PuzzleInput);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
