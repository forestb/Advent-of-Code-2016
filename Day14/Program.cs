using System;
using Day14.Classes;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Input Data
            string samplePuzzleData = "abc";
            string puzzleData = "ihaygndm";

            // Sample, Part 1
            //PuzzleProcessor.ProcessPart1(samplePuzzleData);

            // Day 13, Part 1
            PuzzleProcessor.ProcessPart1(puzzleData);

            // Sample, Part 2
            //PuzzleProcessor.ProcessPart2(samplePuzzleData);

            // Day 13, Part 2
            PuzzleProcessor.ProcessPart2(puzzleData);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
