using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Day15.Classes;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Prepare Data
            List<Disc> samplePuzzleInput = new List<Disc>()
            {
                new Disc(1, 5, 4),
                new Disc(2, 2, 1)
            };

            List<Disc> puzzleInput = new List<Disc>()
            {
                new Disc(1, 17, 15),
                new Disc(2, 3, 2),
                new Disc(3, 19, 4),
                new Disc(4, 13, 2),
                new Disc(5, 7, 2),
                new Disc(6, 5, 0)
            };

            // Sample, Part 1
            PuzzleProcessor.Process(samplePuzzleInput);

            // Live Data, Part 1
            PuzzleProcessor.Process(puzzleInput);

            // Live Data, Part 2
            puzzleInput.Add(new Disc(7, 11, 0));

            PuzzleProcessor.Process(puzzleInput);

            // Finished
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
