using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Day10.Classes.Instructions;

namespace Day10.Classes
{
    public class Values
    {
        public int? HighValue { get; private set; }
        public int? LowValue { get; private set; }
        public int Count => (HighValue == null ? 0 : 1) + (LowValue == null ? 0 : 1);

        public void InsertValue(int value)
        {
            switch (Count)
            {
                case (0):
                    HighValue = value;
                    break;

                case (1):
                    if (HighValue < value)
                    {
                        LowValue = HighValue;
                        HighValue = value;
                    }
                    else
                    {
                        LowValue = value;
                    }
                    break;

                default:
                    throw new Exception("Too many values!");
            }
        }

        public int RemoveHighValue()
        {
            int value = HighValue.GetValueOrDefault(-1);
            HighValue = null;
            return value;
        }

        public int RemoveLowValue()
        {
            int value = LowValue.GetValueOrDefault(-1);
            LowValue = null;
            return value;
        }
    }

    public class Container
    {
        public string Id { get; }
        public string TargetLowId { get; set; }
        public string TargetHighId { get; set; }

        public Values ContainerValues { get; set; }

        public Container(string id)
        {
            Id = id;
            this.ContainerValues = new Values();
        }

        public override bool Equals(object obj)
        {
            var container = obj as Container;

            if (container == null)
            {
                return false;
            }

            return container.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
