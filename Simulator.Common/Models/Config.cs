using System;
using System.Collections.Generic;
using System.Text;
using Utility;
using Utility.DamienG.Security.Cryptography;
using System.Linq;

namespace Simulator.Common.Models
{
    public class Config : TSMBase
    {
        public ConfigCommon Common { get; } = new();
        public List<ConfigItem> Items { get; } = new();
        public uint CRC { get; protected set; }
        public int Padding { get; protected set; }
        public string BitString { get; protected set; }
        public int BlockLength { get; protected set; }
        public byte[] Block { get; protected set; }
        public Config()
        {
        }
        public void Initialize()
        {
            var BlockLength = 12 + Items.Count * 2 + 1;
            BlockLength += Items.Aggregate(0, (a, b) =>
            {
                return StringManipulation.StringToByteArray(b.Payload).Count() + 2;
            });
            //Make encryptable area lie on a 16-byte boundary
            Padding = (BlockLength - 8) % 16;
            if (Padding != 0)
            {
                Padding += 16 - Padding;
                BlockLength += Padding;
            }
        }
        private void AddCrc()
        {
            var initialString = BuildBitString();
            var message = ConvertToByteArray(initialString.Substring(4));
            CRC = Crc32.Compute(message);
            BitString = BuildBitString();
            Block = ConvertToByteArray(BitString);
        }
        private string BuildBitString()
        {
            var result = "";

            result += Convert.ToString((uint)(Common.SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0');
            result += Convert.ToString(Common.MessageType, 2).PadLeft(8, '0');
            result += Convert.ToString((uint)(Common.EffectiveTimeStamp & 0xFFFFFF), 2).PadLeft(24, '0');
            result += Convert.ToString((byte)0, 2).PadLeft(8, '0');

            if (Items != null && Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    result += Convert.ToString((byte)(Items[i].Length & 0xFF), 2).PadLeft(8, '0');
                    result += Convert.ToString((byte)(Items[i].Parameter & 0xFF), 2).PadLeft(8, '0');
                    result += StringManipulation.StringToByteArray(Items[i].Payload).Aggregate(string.Empty, (a, b) => a + Convert.ToString((byte)(b & 0xFF), 2).PadLeft(8, '0'));
                }

                // Add byte with length of 0
                result += "00000000";
            }


            // Add padding
            for (int i = 0; i < Padding; i++)
            {
                result += "00000000";
            }

            result += Convert.ToString(CRC, 2).PadLeft(32, '0');

            return result;
        }
        public override string ToString()
        {
            return BuildBitString();
        }
    }
}
