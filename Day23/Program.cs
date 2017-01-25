using System;
using System.Diagnostics;
using Common;
using Day23.Classes;

namespace Day23
{
    class Program
    {
        public static string PuzzleInputPart1 => PuzzleInputHelper.ReadFile("PuzzleInput_Part1.txt");
        public static string PuzzleInputPart2 => PuzzleInputHelper.ReadFile("PuzzleInput_Part2.txt");
        public static string PuzzleInputPart21 => PuzzleInputHelper.ReadFile("PuzzleInput_Part2_1.txt");
        public static string PuzzleInputPart22 => PuzzleInputHelper.ReadFile("PuzzleInput_Part2_2.txt");
        public static string PuzzleInputPart23 => PuzzleInputHelper.ReadFile("PuzzleInput_Part2_3.txt");
        public static string SamplePuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");

        static void Main(string[] args)
        {
            // Start
            Stopwatch watch = Stopwatch.StartNew();

            // Sample
            //PuzzleProcessor.Process(SamplePuzzleInput);

            // Part 1
            PuzzleProcessor.Process(PuzzleInputPart1);
            Console.WriteLine();

            // Part 2
            PuzzleProcessor.Process(PuzzleInputPart2);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
