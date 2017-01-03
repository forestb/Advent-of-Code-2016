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

            PuzzleData samplePuzzleInput = new PuzzleData(
                rows: 7, 
                columns: 10, 
                favoriteNumber: 10, 
                startingPoint: new Point(1, 1),
                endingPoint: new Point(7, 4));

            PuzzleData puzzleInput = new PuzzleData(
                rows: 50,
                columns: 50,
                favoriteNumber: 1362,
                startingPoint: new Point(1, 1),
                endingPoint: new Point(31, 39));

            // Sample
            //PuzzleProcessor.Process(samplePuzzleInput);

            // Part 1
            // Part 2
            //puzzleInput.PrintGrid();
            PuzzleProcessor.ProcessPart1(puzzleInput);
            puzzleInput.PrintVisitedGrid();

            PuzzleProcessor.ProcessPart2(puzzleInput);
            puzzleInput.PrintVisitedGrid();

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
