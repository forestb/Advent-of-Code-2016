using Day23.Classes.InstructionClasses;

namespace Day23.Interfaces
{
    public interface IInstructionVisitor
    {
        void Visit(CopyInstruction instruction);
        void Visit(IncrimentInstruction instruction);
        void Visit(DecrimentInstruction instruction);
        void Visit(JumpNotZeroInstruction instruction);
        void Visit(ToggleInstruction instruction);
    }
}
