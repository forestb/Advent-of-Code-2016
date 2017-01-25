using System;
using Common;
using Day23.Classes.InstructionClasses;
using Day23.Interfaces;

namespace Day23.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(string puzzleInput)
        {
            string[] parsedPuzzleInputSample = puzzleInput.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            AssembunnyInstructionVisitor visitor = new AssembunnyInstructionVisitor();
            bool shouldToggle = false;

            while (!ExecutionComplete(parsedPuzzleInputSample.Length, visitor.InstructionPointer))
            {
                ProcessInstructionGeneric(parsedPuzzleInputSample[visitor.InstructionPointer], visitor);
            }

            Console.WriteLine($"Register 'a' contains {visitor.Registers["a"]}");
        }

        public static void ProcessInstructionGeneric(string instruction, IInstructionVisitor visitor)
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
            else if (instruction.ContainsLowerInvariant("tgl"))
            {
                new ToggleInstruction(instruction).Accept(visitor);
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
