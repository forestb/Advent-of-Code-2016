using System;
using System.Collections.Generic;

namespace Day15.Classes
{
    public class PuzzleProcessor
    {
        public static void Process_Part1(List<Disc> discs)
        {
            int time = 1;
            int sum = 0;

            while (true)
            {
                foreach (Disc d in discs)
                {
                    sum += d.CalculatePositionAtTime(time);
                }

                if (sum == 0)
                {
                    Console.WriteLine($"Press the button at t={time}.");
                    break;
                }

                sum = 0;
                time++;
            }
        }
    }
}
