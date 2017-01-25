using Day23.Interfaces;

namespace Day23.Classes.InstructionClasses
{
    public class CopyInstruction : Instruction, IInstruction
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public CopyInstruction(string originalInstruction) : base(originalInstruction)
        {
            this.OriginalInstruction = originalInstruction;

            string[] results = Common.SplitOnWhiteSpace(originalInstruction);

            Source = results[1];
            Destination = results[2];
        }

        public void Accept(IInstructionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
