﻿using Day12.Interfaces;

namespace Day12.Classes.InstructionClasses
{
    public class JumpNotZeroInstruction : Instruction
    {
        public string Source { get; set; }
        public int Offset { get; set; }

        public JumpNotZeroInstruction(string originalInstruction) : base(originalInstruction)
        {
            this.OriginalInstruction = originalInstruction;

            string[] results = Common.SplitOnWhiteSpace(originalInstruction);

            Source = results[1];
            Offset = int.Parse(results[2]);
        }

        public void Accept(IInstructionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
