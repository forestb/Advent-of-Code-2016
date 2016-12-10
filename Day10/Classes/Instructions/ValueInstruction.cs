using System;

namespace Day10.Classes.Instructions
{
    public class ValueInstruction
    {
        public int Value { get; set; }
        public string TargetBotId { get; set; }

        public ValueInstruction(string instruction)
        {
            // 1, 6, 11
            string[] results = instruction.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Value = int.Parse(results[1]);
            TargetBotId = Common.CalculateContainerId(results[4].ToLowerInvariant(), results[5]);
        }

        public override string ToString()
        {
            return $"Value={Value};TargetBotId={TargetBotId};";
        }
    }
}
