using System;
using Day16.Classes;

namespace Day16
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Sample Puzzle Input
            PuzzleData samplePuzzleData = new PuzzleData("10000", 20);
            PuzzleProcessor.Process(samplePuzzleData);

            // Real Puzzle Input, Part 1
            PuzzleData puzzleDataPart1 = new PuzzleData("11011110011011101", 272);
            PuzzleProcessor.Process(puzzleDataPart1);

            // Real Puzzle Input, Part 2
            PuzzleData puzzleDataPart2 = new PuzzleData("11011110011011101", 35651584);
            PuzzleProcessor.Process(puzzleDataPart2);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
