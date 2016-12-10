using System;

namespace Day10.Classes.Instructions
{
    public class BotInstruction
    {
        public string BotId { get; set; }
        public string TargetLowId { get; set; }
        public string TargetHighId { get; set; }

        public BotInstruction(string instruction)
        {
            // 1, 6, 11
            string[] results = instruction.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            BotId = Common.CalculateContainerId(results[0], results[1]);
            TargetLowId = Common.CalculateContainerId(results[5].ToLowerInvariant(), results[6].ToLowerInvariant());
            TargetHighId = Common.CalculateContainerId(results[10].ToLowerInvariant(), results[11].ToLowerInvariant());
        }

        public override string ToString()
        {
            return $"BotId={BotId};TargetLowId={TargetLowId};TargetHighId={TargetHighId};";
        }
    }
}
