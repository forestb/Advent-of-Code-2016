using Day23.Interfaces;

namespace Day23.Classes.InstructionClasses
{
    public class NoOpInstruction : Instruction, IInstruction
    {
        public NoOpInstruction(string originalInstruction) : base(originalInstruction)
        {
            this.OriginalInstruction = originalInstruction;
        }

        public void Accept(IInstructionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return $"nop";
        }
    }
}
