using System;

namespace Day8.Classes.Instructions
{
    public class RotateInstruction : InstructionBase
    {
        public Axis TargetAxis { get; }    // column or row
        public int Index { get; }          // the index of the column or row
        public int Value { get; }          // show much to rotate (shift) that column or row by

        public RotateInstruction(string instructionToParse) : base(instructionToParse)
        {       
            // instruction examples:             
            // rotate row y=0 by 4              
            // rotate column x=1 by 1       
            string[] parsedInstruction = instructionToParse.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            // above operation should produce 4 strings, "rotate", "column"/"row", "by", "y=0"/"x=1", "4"/"1"
            TargetAxis = parsedInstruction[1].ToLowerInvariant() == "column" ? Axis.Column : Axis.Row;
            Index = int.Parse(parsedInstruction[2].Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries)[1]);
            Value = int.Parse(parsedInstruction[4]);
        }

        public enum Axis
        {
            Column = 0,
            Row = 1
        }

        public override string ToString()
        {
            return $"TargetAxis={TargetAxis}; Index={Index}; Value={Value}; {base.ToString()}";
        }
    }
}
