using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day10.Classes
{
    public class Common
    {
        public static string CalculateContainerId(string containerType, string containerValue)
        {
            const string VALUE_SEPARATOR = ":";
            return $"{containerType}{VALUE_SEPARATOR}{containerValue}";
        }
    }
}
