using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Day10
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInput_Sample => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");

        static void Main(string[] args)
        {
            Classes.Part1.InstructionProcessor.Process(PuzzleInput, 17, 61);
        }
    }
}
