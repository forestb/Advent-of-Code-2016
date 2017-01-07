using System;
using Day18.Better.Classes;

namespace Day18.Better
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Sample Puzzle Input 1
            PuzzleData samplePuzzleData1 = new PuzzleData("..^^.", 3);
            PuzzleProcessor.Process(samplePuzzleData1, true);
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms elapsed so far.");
            Console.WriteLine();

            // Sample Puzzle Input 2
            PuzzleData samplePuzzleData2 = new PuzzleData(".^^.^.^^^^", 10);
            PuzzleProcessor.Process(samplePuzzleData2);
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms elapsed so far.");
            Console.WriteLine();

            // Actual Puzzle Input, Part 1
            PuzzleData puzzleInput = new PuzzleData(".^^..^...^..^^.^^^.^^^.^^^^^^.^.^^^^.^^.^^^^^^.^...^......^...^^^..^^^.....^^^^^^^^^....^^...^^^^..^", 40);
            PuzzleProcessor.Process(puzzleInput);
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms elapsed so far.");
            Console.WriteLine();

            // Actual Puzzle Input, Part 2
            puzzleInput.RowCount = 400000;
            PuzzleProcessor.Process(puzzleInput);
            Console.WriteLine();

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
