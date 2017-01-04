using System;
using System.Text;

namespace Day16.Classes
{
    public class DragonCurveCheckSumCalculator
    {
        public static string CalculateCheckSum(string str)
        {
            // process the Evaluated string
            StringBuilder checkSum = new StringBuilder();

            // continue reducing the checksum until we get an odd number of characters
            while (String.IsNullOrEmpty(checkSum.ToString()) || checkSum.ToString().Length % 2 == 0)
            {
                checkSum = new StringBuilder();

                char[] evaluatedPairArr = str.ToCharArray();

                for (int i = 0; i < ((str.Length / 2) * 2); i += 2)
                {
                    checkSum.Append((evaluatedPairArr[i] == evaluatedPairArr[i + 1]) ? "1" : "0");
                }

                str = checkSum.ToString();
            }

            return checkSum.ToString();
        }
    }
}
