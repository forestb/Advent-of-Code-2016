using System;
using System.Collections.Generic;
using Common;
using Day10.Classes;

namespace Day10
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInput_Sample => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");

        static void Main(string[] args)
        {
            // Day 10, Part 1
            HashSet<Container> containers = Classes.Part1.InstructionProcessor.Process(PuzzleInput, 17, 61);

            // Day 10, Part 2
            Container bin0 = Container.FindContainerById(containers, "output:0");
            Container bin1 = Container.FindContainerById(containers, "output:1");
            Container bin2 = Container.FindContainerById(containers, "output:2");

            Console.WriteLine($"bin0={bin0.ContainerValues.PeekHighOrLow()}");
            Console.WriteLine($"bin1={bin1.ContainerValues.PeekHighOrLow()}");
            Console.WriteLine($"bin2={bin2.ContainerValues.PeekHighOrLow()}");

            Console.WriteLine(
                $"Result={bin0.ContainerValues.PeekHighOrLow()*bin1.ContainerValues.PeekHighOrLow()*bin2.ContainerValues.PeekHighOrLow()}");
        }
    }
}
