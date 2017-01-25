using Day23.Interfaces;

namespace Day23.Classes.InstructionClasses
{
    public class ToggleInstruction : Instruction, IInstruction
    {
        public string Source { get; set; }

        public ToggleInstruction(string originalInstruction) : base(originalInstruction)
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
