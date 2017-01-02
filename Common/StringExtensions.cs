using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class StringExtensions
    {
        public static bool ContainsLowerInvariant(this string s, string value)
        {
            return s.ToLowerInvariant().Contains(value.ToLowerInvariant());
        }
    }
}
