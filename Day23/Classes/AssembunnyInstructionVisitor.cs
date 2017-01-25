using System.Collections.Generic;
using Day23.Classes.InstructionClasses;
using Day23.Interfaces;

namespace Day23.Classes
{
    public class AssembunnyInstructionVisitor : IInstructionVisitor
    {
        // Registers for the instructions
        public Dictionary<string, int> Registers = new Dictionary<string, int>();
        public int InstructionPointer = 0;

        public AssembunnyInstructionVisitor()
        {
            Registers.Add("a", 0);
            Registers.Add("b", 0);
            Registers.Add("c", 1);
            Registers.Add("d", 0);
        }

        public void Visit(CopyInstruction instruction)
        {
            // source can be either a register or an integer value
            int value = 0;

            if (int.TryParse(instruction.Source, out value))
            {
                // copy value, destination
                Registers[instruction.Destination] = value;
            }
            else
            {
                // copy source, destination
                Registers[instruction.Destination] = Registers[instruction.Source];
            }

            // the instruction is complete
            // point to the next instruction
            InstructionPointer++;
        }

        public void Visit(JumpNotZeroInstruction instruction)
        {
            if (Registers.ContainsKey(instruction.Source))
            {
                // operate on a register
                if (Registers[instruction.Source] != 0)
                {
                    // Instruction.Offset may be negative or positive
                    InstructionPointer += instruction.Offset;
                }
                else
                {
                    // the instruction is complete
                    // point to the next instruction
                    InstructionPointer++;
                }
            }
            else
            {
                // operate on an integer JNZ instruction
                if (int.Parse(instruction.Source) != 0)
                {
                    InstructionPointer += instruction.Offset;
                }
                else
                {
                    // the instruction is complete
                    // point to the next instruction
                    InstructionPointer++;
                }
            }
        }

        public void Visit(IncrimentInstruction instruction)
        {
            Registers[instruction.Source]++;

            // the instruction is complete
            // point to the next instruction
            InstructionPointer++;
        }

        public void Visit(DecrimentInstruction instruction)
        {
            Registers[instruction.Source]--;

            // the instruction is complete
            // point to the next instruction
            InstructionPointer++;
        }

        public void Visit(ToggleInstruction instruction)
        {
            // ex: tgl a (adds value in register a to the instruction pointer)
            InstructionPointer++;
        }
    }
}
