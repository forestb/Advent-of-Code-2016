using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Common;
using Day23.Classes.InstructionClasses;
using Day23.Interfaces;

namespace Day23.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(string puzzleInput)
        {
            Stopwatch watch = Stopwatch.StartNew();

            string[] parsedPuzzleInputSample = puzzleInput.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            // Added to handle comments in puzzle input
            List<string> instructionList = new List<string>();

            foreach (string s in parsedPuzzleInputSample)
            {
                if (!s.Trim().StartsWith("//"))
                {
                    instructionList.Add(s.Trim());
                }
            }

            parsedPuzzleInputSample = instructionList.ToArray();
            // End of addition

            AssembunnyInstructionVisitor visitor = new AssembunnyInstructionVisitor();

            while (!ExecutionComplete(parsedPuzzleInputSample.Length, visitor.InstructionPointer))
            {
                //PrintNewLineExecution(visitor.InstructionPointer, watch);
                ProcessInstruction(parsedPuzzleInputSample[visitor.InstructionPointer], visitor);
            }

            Console.WriteLine($"Register 'a' contains {visitor.Registers["a"]} * Answer to part.");
            Console.WriteLine($"Registers contain {string.Join(" ", visitor.Registers.Values.ToArray())}.");

            watch.Stop();
        }

        public static void ProcessInstruction(string instruction, IInstructionVisitor visitor)
        {
            if (instruction.StartsWith(" "))
            {
                return;
            }

            if (instruction.ContainsLowerInvariant("cpy"))
            {
                if (visitor.ShouldToggle())
                {
                    new JumpNotZeroInstruction(instruction).Accept(visitor);
                }
                else
                {
                    new CopyInstruction(instruction).Accept(visitor);
                }
            }
            else if (instruction.ContainsLowerInvariant("inc"))
            {
                if (visitor.ShouldToggle())
                {
                    new DecrimentInstruction(instruction).Accept(visitor);
                }
                else
                {
                    new IncrimentInstruction(instruction).Accept(visitor);
                }
            }
            else if (instruction.ContainsLowerInvariant("dec"))
            {
                if (visitor.ShouldToggle())
                {
                    new IncrimentInstruction(instruction).Accept(visitor);
                }
                else
                {
                    new DecrimentInstruction(instruction).Accept(visitor);
                }
            }
            else if (instruction.ContainsLowerInvariant("jnz"))
            {
                if (visitor.ShouldToggle())
                {
                    new CopyInstruction(instruction).Accept(visitor);
                }
                else
                {
                    new JumpNotZeroInstruction(instruction).Accept(visitor);
                }
            }
            else if (instruction.ContainsLowerInvariant("tgl"))
            {
                if (visitor.ShouldToggle())
                {
                    new IncrimentInstruction(instruction).Accept(visitor);
                }
                else
                {
                    new ToggleInstruction(instruction).Accept(visitor);
                }
            }
            else if (instruction.ContainsLowerInvariant("mul"))
            {
                new MultiplyInstruction(instruction).Accept(visitor);
            }
            else if (instruction.ContainsLowerInvariant("add"))
            {
                new AddInstruction(instruction).Accept(visitor);
            }
            else if (instruction.ContainsLowerInvariant("nop"))
            {
                new NoOpInstruction(instruction).Accept(visitor);
            }
            else
            {
                throw new Exception("Error: Unknown instruction; cannot process.");
            }
        }

        public static bool ExecutionComplete(int instructionCount, int instructionPointer)
        {
            return instructionPointer > instructionCount - 1;
        }

        private static readonly HashSet<int> EXECUTED_LINES = new HashSet<int>();

        public static void PrintNewLineExecution(int iterator, Stopwatch watch)
        {
            if (EXECUTED_LINES.Add(iterator))
            {
                Console.WriteLine($"Executed line {iterator} at {watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms.");
            }
        }
    }
}
