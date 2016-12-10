using System;

namespace Day8.Classes.Instructions
{
    public class RectInstruction : InstructionBase
    {
        public int Columns { get; }
        public int Rows { get; }

        public RectInstruction(string instructionToParse) : base (instructionToParse)
        {
            // looks like rect 3x2
            string[] results = instructionToParse.Split(new[] {" ", "x"}, StringSplitOptions.RemoveEmptyEntries);

            // should produce 3 strings, "rect", "3", and "2"
            Columns = int.Parse(results[1]);
            Rows = int.Parse(results[2]);
        }

        public override string ToString()
        {
            return $"Columns={Columns}; Rows={Rows}; {base.ToString()}";
        }
    }
}
