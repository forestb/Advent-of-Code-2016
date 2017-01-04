using Common;

namespace Day16.Classes
{
    public class DragonCurveContainer
    {
        public string A { get; }
        public string B { get; }

        public string EvaluatedPair { get; }

        public DragonCurveContainer(string a)
        {
            this.A = a;
            this.B = a.Reverse().Replace('1', '-').Replace('0', '1').Replace('-', '0');
            this.EvaluatedPair = string.Concat(this.A, "0", this.B);
        }

        public override string ToString()
        {
            return EvaluatedPair;
        }
    }
}
