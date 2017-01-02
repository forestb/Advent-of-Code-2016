using System;
using Common;
using Day12.Classes.InstructionClasses;
using Day12.Interfaces;

namespace Day12.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(string[] puzzleInput)
        {
            AssembunnyInstructionVisitor visitor = new AssembunnyInstructionVisitor();

            while (!ExecutionComplete(puzzleInput.Length, visitor.InstructionPointer))
            {
                ProcessInstruction(puzzleInput[visitor.InstructionPointer], visitor);
            }

            Console.WriteLine($"Register a contains {visitor.Registers["a"]}");
        }

        public static void ProcessInstruction(string instruction, IInstructionVisitor visitor)
        {
            if (instruction.ContainsLowerInvariant("cpy"))
            {
                new CopyInstruction(instruction).Accept(visitor);
            }
            else if (instruction.ContainsLowerInvariant("inc"))
            {
                new IncrimentInstruction(instruction).Accept(visitor);
            }
            else if (instruction.ContainsLowerInvariant("dec"))
            {
                new DecrimentInstruction(instruction).Accept(visitor);
            }
            else if (instruction.ContainsLowerInvariant("jnz"))
            {
                new JumpNotZeroInstruction(instruction).Accept(visitor);
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
    }
}
