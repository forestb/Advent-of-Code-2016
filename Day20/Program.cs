using System;
using Common;
using Day20.Classes;

namespace Day20
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInputSample => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");

        const Int64 MAX_IP_L = 4294967295;

        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Sample Input
            // Sample Puzzle Input, Part 1
            PuzzleProcessor.Process_Part1(PuzzleInputSample, 9);

            // Sample puzzle input, Part 2
            PuzzleProcessor.Process_Part2(PuzzleInputSample, 9);

            // Actual Input
            // Actual puzzle input, Part 1
            PuzzleProcessor.Process_Part1(PuzzleInput, MAX_IP_L);

            // Actual puzzle input, Part 2
            PuzzleProcessor.Process_Part2(PuzzleInput, MAX_IP_L);

            // Finished
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
