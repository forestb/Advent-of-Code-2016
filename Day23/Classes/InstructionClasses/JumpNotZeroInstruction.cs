using Day23.Interfaces;

namespace Day23.Classes.InstructionClasses
{
    public class JumpNotZeroInstruction : Instruction, IInstruction
    {
        public string Source { get; set; }
        public string Offset { get; set; }

        public JumpNotZeroInstruction(string originalInstruction) : base(originalInstruction)
        {
            this.OriginalInstruction = originalInstruction;

            string[] results = Common.SplitOnWhiteSpace(originalInstruction);

            Source = results[1];
            Offset = results[2];
        }

        public void Accept(IInstructionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return $"jnz {Source}";
        }
    }
}
