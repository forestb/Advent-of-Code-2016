using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(int elfCount)
        {
            List<Elf> currentRound = new List<Elf>(elfCount);

            // initialize all elves
            for (int i = 1; i <= elfCount; i++)
            {
                currentRound.Add(new Elf(i, true));
            }

            while (currentRound.Count > 1)
            {
                List<Elf> nextRound = new List<Elf>();

                // When the count is even, remove all odd placed elves
                // When the count is odd, remove all odd placed elves, and additionally, the first elf
                int countStart = (currentRound.Count % 2 == 0) ? 0 : 2;

                for (int count = countStart; count < currentRound.Count; count += 2)
                {
                    nextRound.Add(currentRound[count]);
                }

                currentRound = nextRound;
            }

            Console.WriteLine($"With {elfCount} elves, elf #{currentRound.FirstOrDefault()?.Position} gets all the presents.");
        }
    }
}
