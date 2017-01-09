using System;
using Common;
using Day21.Classes;

namespace Day21
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInputSample => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");

        static void Main(string[] args)
        {
            // Start
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Sample puzzle input, Part 1
            const string SAMPLE_INPUT_STRING = "abcde";

            Console.WriteLine("Processing Sample Puzzle...");
            Console.WriteLine($"Input: {SAMPLE_INPUT_STRING}");
            
            string sampleInputForwardResult = PuzzleProcessor.Process_Part1(SAMPLE_INPUT_STRING, PuzzleInputSample);
            Console.WriteLine($"Frwrd: {sampleInputForwardResult}");

            string sampleInputReverseResult = PuzzleProcessor.Process_Part2(sampleInputForwardResult, PuzzleInputSample);
            Console.WriteLine($"Bkwrd: {sampleInputReverseResult}");
            Console.WriteLine($"{Environment.NewLine}");


            // Live input, Part 1
            const string LIVE_INPUT_STRING_PART_1 = "abcdefgh";

            Console.WriteLine("Processing Live Puzzle, Part 1 (and Part 2, well, backwards...)");
            Console.WriteLine($"Input: {LIVE_INPUT_STRING_PART_1}");

            string liveInput1ForwardResult = PuzzleProcessor.Process_Part1(LIVE_INPUT_STRING_PART_1, PuzzleInput);
            Console.WriteLine($"Frwrd: {liveInput1ForwardResult} * Answer to part 1.");

            string liveInput1ReverseResult = PuzzleProcessor.Process_Part2(liveInput1ForwardResult, PuzzleInput);
            Console.WriteLine($"Bkwrd: {liveInput1ReverseResult}");
            Console.WriteLine($"{Environment.NewLine}");


            // Live input, Part 2
            const string LIVE_INPUT_STRING_PART_2 = "fbgdceah";

            Console.WriteLine("Processing Live Puzzle, Part 2 (reversing the new input...)");
            Console.WriteLine($"Input: {LIVE_INPUT_STRING_PART_2}");

            string liveInput2ReverseResult = PuzzleProcessor.Process_Part2(LIVE_INPUT_STRING_PART_2, PuzzleInput);
            Console.WriteLine($"Bkwrd: {liveInput2ReverseResult} * Answer to part 2.");

            // Finished
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"{watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms to complete.");
        }
    }
}
