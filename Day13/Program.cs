using System;
using Common;
using Day13.Classes;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            PuzzleInput samplePuzzle = new PuzzleInput(
                rows: 7, 
                columns: 10, 
                favoriteNumber: 10, 
                startingPoint: new Point(1, 1),
                endingPoint: new Point(7, 4));

            PuzzleInput puzzleInputPart1 = new PuzzleInput(
                rows: 100,
                columns: 100,
                favoriteNumber: 1362,
                startingPoint: new Point(1, 1),
                endingPoint: new Point(31, 39));

            // Sample
            //PuzzleProcessor.Process(samplePuzzle);

            // Part 1
            PuzzleProcessor.Process(puzzleInputPart1);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
