namespace Day23.Interfaces
{
    public interface IInstruction
    {
        void Accept(IInstructionVisitor visitor);
    }
}
