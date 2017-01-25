using Day23.Interfaces;

namespace Day23.Classes.InstructionClasses
{
    public class IncrimentInstruction : Instruction, IInstruction
    {
        public string Destination { get; set; }

        public IncrimentInstruction(string originalInstruction) : base(originalInstruction)
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
            return $"inc {Destination}";
        }
    }
}
