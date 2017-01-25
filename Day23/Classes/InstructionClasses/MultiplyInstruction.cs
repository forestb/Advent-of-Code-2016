using Day23.Interfaces;

namespace Day23.Classes.InstructionClasses
{
    public class MultiplyInstruction : Instruction, IInstruction
    {
        public string Source1 { get; set; }
        public string Source2 { get; set; }
        public string Destination { get; set; }

        public MultiplyInstruction(string originalInstruction) : base(originalInstruction)
        {
            this.OriginalInstruction = originalInstruction;

            string[] results = Common.SplitOnWhiteSpace(originalInstruction);

            Source1 = results[1];
            Source2 = results[2];
            Destination = results[3];
        }

        public void Accept(IInstructionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return $"mul {Source1} {Source2} {Destination}";
        }
    }
}
