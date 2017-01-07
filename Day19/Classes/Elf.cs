namespace Day19.Classes
{
    public class Elf
    {
        public int Position { get; set; }
        public bool IsValid { get; set; }

        public Elf(int position, bool isValid)
        {
            Position = position;
            IsValid = isValid;
        }
    }
}
