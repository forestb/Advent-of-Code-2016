using System;
using Common;
using Day9.Part1;

namespace Day9
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        
        static void Main(string[] args)
        {
            bool useSampleData = false;

            // Day 9, Part 1
            string puzzleInputPart1 = useSampleData
                ? Day9.PuzzleInput.PuzzleQa.PuzzleInputPart1Sample6.Input
                : PuzzleInput;

            Console.WriteLine($"Day 9, Part 1 Answer: {InstructionProcessor.Process(puzzleInputPart1)}");

            // Day 9, Part 2
            string puzzleInputPart2 = useSampleData
                ? Day9.PuzzleInput.PuzzleQa.PuzzleInputPart2Sample4.Input
                : PuzzleInput;

            Console.WriteLine($"Day 9, Part 2 Answer: {Part2.InstructionProcessor.Process(puzzleInputPart2)}");
        }
    }
}
