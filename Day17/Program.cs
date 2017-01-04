using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            PuzzleProcessor.Process(samplePuzzleInput1, startingPoint, endingPoint);

            // Sample Puzzle Input 2
            PuzzleData samplePuzzleInput2 = new PuzzleData("ihgpwlah", 4, 4);
            PuzzleProcessor.Process(samplePuzzleInput2, startingPoint, endingPoint);

            // Live Data, Part 1
            PuzzleData puzzleInput = new PuzzleData("qzthpkfp", 4, 4);
            PuzzleProcessor.Process(puzzleInput, startingPoint, endingPoint);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
