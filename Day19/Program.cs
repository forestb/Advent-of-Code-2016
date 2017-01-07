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

            int samplePuzzleInput = 5;
            int puzzleInput = 3001330;

            // Sample Data, Part 1
            PuzzleProcessor.Process_Part1(samplePuzzleInput);

            // Live Data, Part 1
            PuzzleProcessor.Process_Part1(puzzleInput);

            // Sample Data, Part 2
            PuzzleProcessor.Process_Part2(samplePuzzleInput);

            // Test Data, Part 2
            //PuzzleProcessor.Process_Part2(puzzleInput);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
