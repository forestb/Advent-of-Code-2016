using Day12.Interfaces;

namespace Day12.Classes.InstructionClasses
{
    public class IncrimentInstruction : Instruction
    {
        public string Source { get; set; }

        public IncrimentInstruction(string originalInstruction) : base(originalInstruction)
        {
            this.OriginalInstruction = originalInstruction;

            string[] results = Common.SplitOnWhiteSpace(originalInstruction);

            Source = results[1];
        }

        public void Accept(IInstructionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
