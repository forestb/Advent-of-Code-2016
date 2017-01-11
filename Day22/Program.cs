using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Day22.Classes;

namespace Day22
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");

        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Part 1
            PuzzleProcessor.Process(PuzzleInput);

            // Finished
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
