using Day23.Interfaces;

namespace Day23.Classes.InstructionClasses
{
    public class DecrimentInstruction : Instruction, IInstruction
    {
        public string Destination { get; set; }

        public DecrimentInstruction(string originalInstruction) : base(originalInstruction)
        {
            this.OriginalInstruction = originalInstruction;

            string[] results = Common.SplitOnWhiteSpace(originalInstruction);

            Destination = results[1];
        }

        public void Accept(IInstructionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return $"dec {Destination}";
        }
    }
}
