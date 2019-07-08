using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Utilities
{
    /// <summary>
    /// Contains static methods for integer extentions
    /// </summary>
    public static class IntegerExtentions
    {
        /// <summary>
        /// Returns string with hexademical value of integer
        /// </summary>
        /// <param name="value">Integer</param>
        /// <returns></returns>
        public static string ToHexademicalString(this int value)
        {
            return value.ToString("X");
        }

        /// <summary>
        /// Returns string with hexademical value of integer with 0x prefix
        /// </summary>
        /// <param name="value">Integer</param>
        /// <returns></returns>
        public static string ToHexademicalStringWithPrefix(this int value)
        {
            return "0x" + value.ToHexademicalString();
        }
    }
}
