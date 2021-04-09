using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public static class StringManipulation
    {
		private static IEnumerable<string> SubStrings(string str)
		{
			for (int i = 0; i < str.Length; i += 2)
			{
				yield return str[i..(i+2)];
			}
		}
		public static IEnumerable<byte> StringToByteArray(this string str)
		{
				if (string.IsNullOrWhiteSpace(str)) return Enumerable.Empty<byte>();
				if (str.Length == 2 || str.Contains("-"))
				{
					str = str.Replace("-", "");
					if (str.Length % 2 == 1)
						throw new Exception("The binary key cannot have an odd number of digits");

					return SubStrings(str).Select(s => (byte)Int32.Parse(s, System.Globalization.NumberStyles.HexNumber));
				}

				return Encoding.ASCII.GetBytes(str);
		}
	}
}
