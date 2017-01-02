namespace Day12.Classes.InstructionClasses
{
    public abstract class Instruction
    {
        public string OriginalInstruction { get; set; }

        protected Instruction(string instruction)
        {
            this.OriginalInstruction = instruction;
        }

        public override string ToString()
        {
            return $"{OriginalInstruction}";
        }
    }
}
