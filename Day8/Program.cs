using System;
using Common;
using Day8.Classes;

namespace Day8
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInputSample => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");

        static void Main(string[] args)
        {
            // Select from either Sample Input or (Live) Input
            bool useSampleData = false;

            Screen s = null;
            string fileContents = null;

            if (useSampleData)
            {
                s = new Screen(7, 3);
                fileContents = PuzzleInputSample;
            }
            else
            {
                s = new Screen(50, 6);
                fileContents = PuzzleInput;
            }

            // Day 8, Part 1
            string[] instructionSet = fileContents.Split(new[] {Environment.NewLine}, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string instruction in instructionSet)
            {
                s.ProcessInstruction(instruction);
            }

            Console.WriteLine($"{s.GetActivePixelCount} pixels are active.");

            // Day 8, Part 2
            s.PrintGrid();
        }
    }
}
