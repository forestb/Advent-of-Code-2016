using System;
using Common;

namespace Day21.Classes
{
    public class PuzzleRules
    {
        public static string ProcessRule(string startingString, string puzzleRule, bool shouldInvertInstruction = false)
        {
            string[] parsedPuzzleRule = puzzleRule.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            // Process the rule
            if (puzzleRule.StartsWithLowerInvariant("swap position"))
            {
                // swap position X with position Y
                // the letters at indexes X and Y (counting from 0) should be swapped.
                int x = int.Parse(parsedPuzzleRule[2]);
                int y = int.Parse(parsedPuzzleRule[5]);

                if (shouldInvertInstruction)
                {
                    return startingString.IndexSwap(y, x);
                }

                return startingString.IndexSwap(x, y);
            }
            else if (puzzleRule.StartsWithLowerInvariant("swap letter"))
            {
                // swap letter X with letter Y
                // the letters X and Y should be swapped (regardless of where they appear in the string).
                char x = char.Parse(parsedPuzzleRule[2]);
                char y = char.Parse(parsedPuzzleRule[5]);

                if (shouldInvertInstruction)
                {
                    return startingString.LetterSwap(y, x);
                }

                return startingString.LetterSwap(x, y);
            }
            else if (puzzleRule.StartsWithLowerInvariant("rotate left") || 
                     puzzleRule.StartsWithLowerInvariant("rotate right"))
            {
                // rotate left/right X steps
                // means that the whole string should be rotated; for example, one right rotation would turn abcd into 
                // dabc.
                StringRotateDirection direction = parsedPuzzleRule[1].StartsWithLowerInvariant("left")
                    ? StringRotateDirection.Left
                    : StringRotateDirection.Right;

                int x = int.Parse(parsedPuzzleRule[2]);

                if (shouldInvertInstruction)
                {
                    direction = direction == StringRotateDirection.Left
                        ? StringRotateDirection.Right
                        : StringRotateDirection.Left;

                    return startingString.RotateDirection(direction, x);
                }

                return startingString.RotateDirection(direction, x);
            }
            else if (puzzleRule.StartsWithLowerInvariant("rotate based on"))
            {
                // rotate based on position of letter X
                // means that the whole string should be rotated to the right based on the index of letter X 
                // (counting from 0) as determined before this instruction does any rotations. Once the index is 
                // determined, rotate the string to the right one time, plus a number of times equal to that index, 
                // plus one additional time if the index was at least 4.
                char x = char.Parse(parsedPuzzleRule[6]);

                if (shouldInvertInstruction)
                {
                    return startingString.RotateLeftBasedOnPositionOf(x);
                }

                return startingString.RotateRightBasedOnPositionOf(x);
            }
            else if (puzzleRule.StartsWithLowerInvariant("reverse"))
            {
                // reverse positions X through Y
                // means that the span of letters at indexes X through Y (including the letters at X and Y) should be 
                // reversed in order.
                int x = int.Parse(parsedPuzzleRule[2]);
                int y = int.Parse(parsedPuzzleRule[4]);

                // nothing should be needed for an inverted instruction here
                //if (shouldInvertInstruction)
                //{
                //    return startingString.ReverseByPositions(y, x);
                //}

                return startingString.ReverseByPositions(x, y);
            }
            else if (puzzleRule.StartsWithLowerInvariant("move"))
            {
                // move position X to position Y
                // means that the letter which is at index X should be removed from the string, then inserted such 
                // that it ends up at index Y.
                int x = int.Parse(parsedPuzzleRule[2]);
                int y = int.Parse(parsedPuzzleRule[5]);

                if (shouldInvertInstruction)
                {
                    return startingString.MoveByPosition(y, x);
                }

                return startingString.MoveByPosition(x, y);
            }
            else
            {
                throw new Exception("Unknown command found; could not process.");
            }
        }
    }
}
