using System;
using Common;
using Day17.Classes;

namespace Day17
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Point startingPoint = new Point(0, 0);
            Point endingPoint = new Point(3, 3);

            // Sample Puzzle Input 1
            PuzzleData samplePuzzleInput1 = new PuzzleData("hijkl", 4, 4);
            PuzzleProcessor.Process_Part1(samplePuzzleInput1, startingPoint, endingPoint);

            // Sample Puzzle Input 2
            PuzzleData samplePuzzleInput2 = new PuzzleData("ihgpwlah", 4, 4);
            PuzzleProcessor.Process_Part1(samplePuzzleInput2, startingPoint, endingPoint);

            // Live Data, Part 1
            PuzzleData puzzleInput = new PuzzleData("qzthpkfp", 4, 4);
            PuzzleProcessor.Process_Part1(puzzleInput, startingPoint, endingPoint);

            // Live Data, Part 2
            PuzzleProcessor.Process_Part2(puzzleInput, startingPoint, endingPoint);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
