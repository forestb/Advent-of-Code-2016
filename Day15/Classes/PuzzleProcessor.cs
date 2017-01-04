using System;
using System.Collections.Generic;

namespace Day15.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(List<Disc> discs)
        {
            int time = 0;
            int sum = 0;

            do
            {
                sum = 0;
                time++;

                foreach (Disc d in discs)
                {
                    sum += d.CalculatePositionAtTime(time);
                }
            } while (sum != 0);

            Console.WriteLine($"With the {discs.Count} discs, press the button at t={time}.");
        }
    }
}
