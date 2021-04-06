using System;
using System.Collections.Generic;
using Utility.DamienG.Security.Cryptography;

namespace Simulator.Common.Models
{
    public abstract class TSMBase
    {
        public abstract string BuildBitString();
        public abstract void Initialize();
        internal protected void AddCrc()
        {
            var initialString = BuildBitString();
            var message = ConvertToByteArray(initialString.Substring(4));
            CRC = Crc32.Compute(message);
            BitString = BuildBitString();
            //var splitString = new string(SplitString(BitString).ToArray());
            Block = ConvertToByteArray(BitString);
        }
        internal string BitString { get; set; }
        internal int Padding { get; set; }
        public byte[] Block { get; protected set; }
        internal protected uint CRC { get; protected set; }
        internal protected static byte[] ConvertToByteArray(string inputBitString)
        {
            List<byte> byteList = new List<byte>();
            for (int i = inputBitString.Length - 1; i >= 0; i -= 8)
            {
                string byteString = "";
                for (int j = 0; (i - j) >= 0 && j < 8; j++)
                {
                    byteString = inputBitString[i - j] + byteString;
                }
                if (byteString != "")
                {
                    byteList.Add(Convert.ToByte(byteString, 2));
                }
            }
            return byteList.ToArray();
        }
    }
}
