using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day10.Classes.Instructions
{
    public class InstructionParser
    {
        private static string[] GetParsedInstructions(string instructionSet)
            => instructionSet.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        public static List<object> ParseInstructions(string input)
        {
            string[] instructionSet = GetParsedInstructions(input);
            List<object> instructionList = new List<object>();

            foreach (string s in instructionSet)
            {
                if (s.ToLowerInvariant().StartsWith("bot"))
                {
                    instructionList.Add(new BotInstruction(s));
                }
                else if (s.ToLowerInvariant().StartsWith("value"))
                {
                    instructionList.Add(new ValueInstruction(s));
                }
                else
                {
                    throw new Exception("Invalid instructions. Cannot process.");
                }
            }

            return instructionList;
        }
    }
}
