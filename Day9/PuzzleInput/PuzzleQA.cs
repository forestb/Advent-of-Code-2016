namespace Day9.PuzzleInput
{
    public static class PuzzleQa
    {
        public static Qa PuzzleInputPart1Sample1 => new Qa("ADVENT", "ADVENT");
        public static Qa PuzzleInputPart1Sample2 => new Qa("A(1x5)BC", "ABBBBBC");
        public static Qa PuzzleInputPart1Sample3 => new Qa("(3x3)XYZ", "XYZXYZXYZ");
        public static Qa PuzzleInputPart1Sample4 => new Qa("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG");   
        public static Qa PuzzleInputPart1Sample5 => new Qa("(6x1)(1x3)A", "(1x3)A");          
        public static Qa PuzzleInputPart1Sample6 => new Qa("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY");

        // part 2
        public static Qa PuzzleInputPart2Sample1 => new Qa("(3x3)XYZ", "XYZXYZXYZ");
        public static Qa PuzzleInputPart2Sample2 => new Qa("X(8x2)(3x3)ABCY", "XABCABCABCABCABCABCY");
        public static Qa PuzzleInputPart2Sample3 => new Qa("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920);
        public static Qa PuzzleInputPart2Sample4 => new Qa("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445);
    }

    public class Qa
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        public ulong? ExpectedOutputLength { get; set; }

        public Qa(string input, ulong? expectedOutputLength, string expectedOutput) : this(input, expectedOutputLength)
        {
            ExpectedOutput = expectedOutput;
        }

        public Qa(string input, ulong? expectedOutputLength)
        {
            this.Input = input;
            this.ExpectedOutputLength = (ulong?)expectedOutputLength;
        }

        public Qa(string input, string expectedOutput) : this(input, (ulong?)expectedOutput?.Length, expectedOutput)
        {
            
        }
    }
}
