using System;
using System.Collections.Generic;
using System.Text;
using Utility.DamienG.Security.Cryptography;

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
            Padding = (Items.Count + 8) % 16;
            if (Padding != 0)
            {
                Padding += 16 - Padding;
            }
            BlockLength = Padding + 12 + Items.Count * 4;
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
                    result += Convert.ToString((byte)(Items[i].Payload & 0xFF), 2).PadLeft(8, '0');
                }
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
