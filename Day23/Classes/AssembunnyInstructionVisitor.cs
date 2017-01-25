using System;
using System.Collections.Generic;
using System.Linq;
using Day23.Classes.InstructionClasses;
using Day23.Interfaces;

namespace Day23.Classes
{
    public class AssembunnyInstructionVisitor : IInstructionVisitor
    {
        // Registers for the instructions
        public Dictionary<string, int> Registers = new Dictionary<string, int>();
        public Dictionary<int, bool> ToggleBits = new Dictionary<int, bool>();
        public int InstructionPointer = 0;

        public AssembunnyInstructionVisitor()
        {
            Registers.Add("a", 0);
            Registers.Add("b", 0);
            Registers.Add("c", 1);
            Registers.Add("d", 0);
        }

        public bool ShouldToggle()
        {
            return ToggleBits.ContainsKey(InstructionPointer) && ToggleBits[InstructionPointer];
        }

        public void Visit(CopyInstruction instruction)
        {
            PrintInstruction(instruction);

            if (!Registers.ContainsKey(instruction.Destination))
            {
                // Invalid instruction
                // The destination must be a register
                InstructionPointer++;
                return;
            }

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
            PrintInstruction(instruction);

            int sourceValueInRegister = Registers.ContainsKey(instruction.Source)
                ? Registers[instruction.Source]
                : int.Parse(instruction.Source);

            int offsetValue = Registers.ContainsKey(instruction.Offset)
                ? Registers[instruction.Offset]
                : int.Parse(instruction.Offset);

            if (sourceValueInRegister != 0)
            {
                // Instruction.Offset may be negative or positive
                InstructionPointer += offsetValue;
            }
            else
            {
                // the instruction is complete
                // point to the next instruction
                InstructionPointer++;
            }
        }

        public void Visit(IncrimentInstruction instruction)
        {
            PrintInstruction(instruction);

            Registers[instruction.Destination]++;

            // the instruction is complete
            // point to the next instruction
            InstructionPointer++;
        }

        public void Visit(DecrimentInstruction instruction)
        {
            PrintInstruction(instruction);

            Registers[instruction.Destination]--;

            // the instruction is complete
            // point to the next instruction
            InstructionPointer++;
        }

        public void Visit(ToggleInstruction instruction)
        {
            PrintInstruction(instruction);

            // ex: tgl a (adds value in register a to the instruction pointer)
            int valueInRegister = Registers[instruction.Source];
            int valueToToggle = valueInRegister + InstructionPointer;

            if (ToggleBits.ContainsKey(valueToToggle))
            {
                ToggleBits[valueToToggle] = true;
            }
            else
            {
                ToggleBits.Add(valueToToggle, true);
            }

            InstructionPointer++;
        }

        public void Visit(MultiplyInstruction instruction)
        {
            PrintInstruction(instruction);

            // ex: mul a b c (multiplies a * b and puts it in c)
            int sourceValue1 = Registers[instruction.Source1];
            int sourceValue2 = Registers[instruction.Source2];

            Registers[instruction.Destination] += sourceValue1 * sourceValue2;

            InstructionPointer++;
        }

        public void Visit(AddInstruction instruction)
        {
            PrintInstruction(instruction);

            int sourceValue1InRegister = Registers.ContainsKey(instruction.Source1)
                ? Registers[instruction.Source1]
                : int.Parse(instruction.Source1);

            int sourceValue2InRegister = Registers.ContainsKey(instruction.Source2)
                ? Registers[instruction.Source2]
                : int.Parse(instruction.Source2);

            Registers[instruction.Destination] += sourceValue1InRegister + sourceValue2InRegister;

            // the instruction is complete
            // point to the next instruction
            InstructionPointer++;
        }

        public void Visit(NoOpInstruction instruction)
        {
            InstructionPointer++;
        }

        private void PrintInstruction(IInstruction instruction)
        {
            //Console.WriteLine($"{instruction.ToString().PadRight(10)}{string.Join(" ", Registers.Values.ToArray())}");
        }
    }
}
