using System;
using System.Text.RegularExpressions;

namespace Utility
{
    public static class Utility
    {
        public static int ParseIntegerValue(string sv)
        {
            if (new Regex(@"[A-Fa-f]|0x").IsMatch(sv))
            {
                return Convert.ToInt32(sv, 16);
            }
            else
            {
                return Convert.ToInt32(sv);
            }
        }
    }
}
