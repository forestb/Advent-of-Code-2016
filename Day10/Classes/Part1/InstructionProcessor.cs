using System;
using System.Collections.Generic;
using System.Linq;
using Day10.Classes.Instructions;

namespace Day10.Classes.Part1
{
    public class InstructionProcessor
    {
        public static void Process(string instructions, int lowValueToFind, int highValueToFind)
        {
            // parse the input
            List<object> instructionSet = InstructionParser.ParseInstructions(instructions);

            List<BotInstruction> botInstructions = new List<BotInstruction>();
            List<ValueInstruction> valueInstructions = new List<ValueInstruction>();

            foreach (object o in instructionSet)
            {
                if (o is BotInstruction)
                {
                    botInstructions.Add((BotInstruction)o);
                }
                else if (o is ValueInstruction)
                {
                    valueInstructions.Add((ValueInstruction)o);
                }
            }

            // Prepare the container list
            HashSet<Container> containers = new HashSet<Container>();
            
            foreach(BotInstruction i in botInstructions)
            {
                if (!containers.Add(new Container(i.BotId) {TargetLowId = i.TargetLowId, TargetHighId = i.TargetHighId}))
                {
                    Container updateContainer = containers.FirstOrDefault(u => u.Id == i.BotId);

                    updateContainer.TargetLowId = i.TargetLowId;
                    updateContainer.TargetHighId = i.TargetHighId;
                }

                containers.Add(new Container(i.TargetLowId));
                containers.Add(new Container(i.TargetHighId));
            }

            // Load up the values
            foreach (ValueInstruction v in valueInstructions)
            {
                FindContainerById(containers, v.TargetBotId).ContainerValues.InsertValue(v.Value);
            }

            // Once the data is loaded, ensure there's only one node with 2 values
            int containersToProcessCount = containers.Count(cc => cc.ContainerValues.Count >= 2);

            if (containersToProcessCount != 1)
            {
                throw new Exception("Error: Too many containers with at least 2 starting values.");
            }

            // Begin the container traversal
            while (ShouldContinueProcessing(containers))
            {
                Container containerToProcess = NextContainerToProcess(containers);

                int lowValue = containerToProcess.ContainerValues.RemoveLowValue();
                int highValue = containerToProcess.ContainerValues.RemoveHighValue();

                // Condition for solving the puzzle
                if (lowValue == lowValueToFind && highValue == highValueToFind)
                {
                    Console.WriteLine(containerToProcess.Id);
                }

                Container targetLowContainer = FindContainerById(containers, containerToProcess.TargetLowId);
                targetLowContainer.ContainerValues.InsertValue(lowValue);

                Container targetHighContainer = FindContainerById(containers, containerToProcess.TargetHighId);
                targetHighContainer.ContainerValues.InsertValue(highValue);
            }
        }

        public static Container NextContainerToProcess(HashSet<Container> containers)
            => containers.FirstOrDefault(c => c.ContainerValues.Count == 2);

        public static bool ShouldContinueProcessing(HashSet<Container> containers)
            => NextContainerToProcess(containers) != null;

        public static Container FindContainerById(HashSet<Container> containers, string id)
            => containers.FirstOrDefault(c => c.Id == id);
    }
}
