using System;
using Common;
using Day22.Classes;

namespace Day22
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInputReduced => PuzzleInputHelper.ReadFile("PuzzleInputReduced.txt");
        public static string SamplePuzzleInput => PuzzleInputHelper.ReadFile("SamplePuzzleInput.txt");
        public static string SamplePuzzleInputSmaller => PuzzleInputHelper.ReadFile("SamplePuzzleInputSmaller.txt");

        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Part 1
            PuzzleProcessor.Process_Part1(PuzzleInput);
            Console.WriteLine();

            // Part 2, Sample (Smaller)
            //...PuzzleProcessor.Process_Part2(SamplePuzzleInputSmaller);

            // Part 2, Sample
            PuzzleProcessor.Process_Part2(SamplePuzzleInput);
            Console.WriteLine();

            // Part 2, Real Input
            PuzzleProcessor.Process_Part2_Math(PuzzleInput);
            Console.WriteLine();

            // Finished
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
