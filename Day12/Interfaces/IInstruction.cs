namespace Day12.Interfaces
{
    public interface IInstruction
    {
        void Accept(IInstructionVisitor visitor);
    }
}
