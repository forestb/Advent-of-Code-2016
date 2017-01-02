using Day12.Classes.InstructionClasses;

namespace Day12.Interfaces
{
    public interface IInstructionVisitor
    {
        void Visit(CopyInstruction instruction);
        void Visit(IncrimentInstruction instruction);
        void Visit(DecrimentInstruction instruction);
        void Visit(JumpNotZeroInstruction instruction);
    }
}
