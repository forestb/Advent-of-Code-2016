using System;

namespace Day16.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(PuzzleData pd)
        {
            // Fill the disk
            DragonCurveContainer currentContainer = new DragonCurveContainer(pd.InitialState);
            DragonCurveContainer tempContainer = null;
            int count = 1;

            while (currentContainer.EvaluatedPair.Length < pd.TargetDiskSize)
            {
                count++;
                tempContainer = currentContainer;
                currentContainer = new DragonCurveContainer(tempContainer.EvaluatedPair);
            }

            Console.WriteLine($"The disk is full; it took {count} attempts with a length of {currentContainer.EvaluatedPair.Length}.");

            // Prepare the substring, which fills the disk
            string dragonCurveSubstr = currentContainer.EvaluatedPair.Substring(0, pd.TargetDiskSize);

            // Calculate the checksum on this value
            string checkSum = DragonCurveCheckSumCalculator.CalculateCheckSum(dragonCurveSubstr);

            // Output the checksum
            Console.WriteLine($"The checksum is {checkSum}.");
        }
    }
}
