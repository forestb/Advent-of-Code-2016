using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            // Sample
            //PuzzleProcessor.Process(samplePuzzleData);

            // Day 13, Part 1
            PuzzleProcessor.Process(puzzleData);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
