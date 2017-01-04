using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day17.Classes
{
    public class PuzzleProcessor
    {
        public static void Process_Part1(PuzzleData pd, Point startingPoint, Point endingPoint)
        {
            // Queue up initial state
            Queue<Traveler> travelerQueue = new Queue<Traveler>();
            travelerQueue.Enqueue(new Traveler(pd, startingPoint, string.Empty));

            while (travelerQueue.Count > 0)
            {
                Traveler t = travelerQueue.Dequeue();

                if (Equals(t.CurrentPoint, endingPoint))
                {
                    // Success
                    Console.WriteLine($"Success, a traveler reached the vault using the path {t.PathSoFar}");
                    return;
                }

                if (t.CanMoveUp)
                {
                    travelerQueue.Enqueue(t.MoveUp());
                }

                if (t.CanMoveDown)
                {
                    travelerQueue.Enqueue(t.MoveDown());
                }

                if (t.CanMoveLeft)
                {
                    travelerQueue.Enqueue(t.MoveLeft());
                }

                if (t.CanMoveRight)
                {
                    travelerQueue.Enqueue(t.MoveRight());
                }
            }

            Console.WriteLine($"With a passcode of {pd.Passcode}, we'll never get to the vault...");
        }

        public static void Process_Part2(PuzzleData pd, Point startingPoint, Point endingPoint)
        {
            // Queue up initial state
            Queue<Traveler> travelerQueue = new Queue<Traveler>();
            travelerQueue.Enqueue(new Traveler(pd, startingPoint, string.Empty));

            List<Traveler> successfulTravelers = new List<Traveler>();

            while (travelerQueue.Count > 0)
            {
                Traveler t = travelerQueue.Dequeue();

                if (Equals(t.CurrentPoint, endingPoint))
                {
                    // Success
                    successfulTravelers.Add(t);
                }
                else
                {
                    if (t.CanMoveUp)
                    {
                        travelerQueue.Enqueue(t.MoveUp());
                    }

                    if (t.CanMoveDown)
                    {
                        travelerQueue.Enqueue(t.MoveDown());
                    }

                    if (t.CanMoveLeft)
                    {
                        travelerQueue.Enqueue(t.MoveLeft());
                    }

                    if (t.CanMoveRight)
                    {
                        travelerQueue.Enqueue(t.MoveRight());
                    }
                }
            }

            Console.WriteLine($"There were {successfulTravelers.Count} successful travelers.");
            Console.WriteLine($"The longest path was {successfulTravelers.OrderByDescending(x => x.PathSoFar.Length).Take(1).FirstOrDefault()?.PathSoFar.Length}");
        }
    }
}
