using System;
using System.Linq;
using System.Text;

namespace Day21.Classes
{
    public enum StringRotateDirection
    {
        Left = 0,
        Right
    }

    public static class PuzzleExtensions
    {
        /// <summary>
        /// swap position X with position Y means that the letters at indexes X and Y (counting from 0) should be 
        /// swapped.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static string IndexSwap(this string s, int x, int y)
        {
            StringBuilder tempString = new StringBuilder(s)
            {
                [x] = s[y],
                [y] = s[x]
            };

            return tempString.ToString();
        }

        /// <summary>
        /// swap letter X with letter Y means that the letters X and Y should be swapped (regardless of where they 
        /// appear in the string).
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static string LetterSwap(this string s, char x, char y)
        {
            StringBuilder tempString = new StringBuilder(s);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == x)
                {
                    tempString[i] = y;
                }
                else if (s[i] == y)
                {
                    tempString[i] = x;
                }
            }

            return tempString.ToString();
        }

        /// <summary>
        /// rotate left/right X steps means that the whole string should be rotated; for example, one right rotation 
        /// would turn abcd into dabc.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="direction"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string RotateDirection(this string s, StringRotateDirection direction, int x)
        {
            switch (direction)
            {
                case (StringRotateDirection.Left):
                    // This is the length we need to shift the string without repeats/looping back
                    int shiftLeftCount = x % s.Length;

                    // Copy the substring into the container
                    return
                        new StringBuilder(
                            string.Concat(
                                s.Substring(shiftLeftCount, s.Length - shiftLeftCount),
                                s.Substring(0, shiftLeftCount))).ToString();

                case (StringRotateDirection.Right):
                    // This is the length we need to shift the string without repeats/looping back
                    int shiftRightCount = x % s.Length;

                    // Copy the substring into the container
                    return
                        new StringBuilder(
                            string.Concat(
                                s.Substring(s.Length - shiftRightCount, shiftRightCount),
                                s.Substring(0, s.Length - shiftRightCount))).ToString();

                default:
                    throw new Exception("Direction not supported.");
            }
        }

        /// <summary>
        /// rotate based on position of letter X means that the whole string should be rotated to the right based on 
        /// the index of letter X (counting from 0) as determined before this instruction does any rotations. Once the 
        /// index is determined, rotate the string to the right one time, plus a number of times equal to that index, 
        /// plus one additional time if the index was at least 4
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string RotateRightBasedOnPositionOf(this string s, char x)
        {
            int indexOf = s.IndexOf(x.ToString(), StringComparison.Ordinal);

            return
                indexOf < 4
                    ? s.RotateDirection(StringRotateDirection.Right, 1 + indexOf)
                    : s.RotateDirection(StringRotateDirection.Right, 1 + indexOf + 1);
        }

        /// <summary>
        /// applies the inverse of RotateRightBasedOnPositionOf();
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string RotateLeftBasedOnPositionOf(this string s, char x)
        {
            // since we've lost some of the information to transform it directly, test all possibilities such that
            // re-applying the same transformation gets us the original value back.
            string candidateString = string.Empty;

            for (int i = 1; i <= s.Length; i++)
            {
                string s1 = s.RotateDirection(StringRotateDirection.Left, i);
                string s2 = s1.RotateRightBasedOnPositionOf(x);

                if (s2 == s)
                {
                    candidateString = s1;
                    break;
                }
            }

            return candidateString;
        }

        /// <summary>
        /// reverse positions X through Y means that the span of letters at indexes X through Y (including the letters 
        /// at X and Y) should be reversed in order.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseByPositions(this string s, int x, int y)
        {
            StringBuilder tempString = new StringBuilder();

            int reverseLengthInclusive = y - x + 1;

            string start = s.Substring(0, x);
            char[] reversedSubstring = s.Substring(x, reverseLengthInclusive).ToCharArray().Reverse().ToArray();

            tempString.Append(start);
            tempString.Append(reversedSubstring);

            // end of string
            int yBoundary = y + 1;
            if (yBoundary < s.Length)
            {
                string end = s.Substring(yBoundary, s.Length - yBoundary);
                tempString.Append(end);
            }

            return tempString.ToString();
        }

        /// <summary>
        /// move position X to position Y means that the letter which is at index X should be removed from the string, 
        /// then inserted such that it ends up at index Y.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static string MoveByPosition(this string s, int x, int y)
        {
            StringBuilder tempString = new StringBuilder(s);

            if (x < y)
            {
                // If the character to remove comes before t
                tempString.Insert(y + 1, s[x]);
                tempString.Remove(x, 1);
            }
            else
            {
                // remove first, insert after
                tempString.Remove(x, 1);
                tempString.Insert(y, s[x]);
            }

            return tempString.ToString();
        }
    }
}
