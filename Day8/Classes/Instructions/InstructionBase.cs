namespace Day8.Classes.Instructions
{
    public class InstructionBase
    {
        public string OriginalInstruction { get; set; }

        public InstructionBase(string originalInstruction)
        {
            this.OriginalInstruction = originalInstruction;
        }

        public override string ToString()
        {
            return $"{OriginalInstruction}";
        }
    }
}
