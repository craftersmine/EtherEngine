using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Utilities
{
    public static class IntegerExtentions
    {
        public static string ToHexademicalString(this int value)
        {
            return value.ToString("X");
        }

        public static string ToHexademicalStringWithPrefix(this int value)
        {
            return "0x" + value.ToHexademicalString();
        }
    }
}
