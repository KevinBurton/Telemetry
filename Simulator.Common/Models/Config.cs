using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Simulator.Common.Models
{
    public class Config : TSMBase
    {
        public ConfigCommon Common { get; } = new();
        public List<ConfigItem> Items { get; } = new();
        public Config()
        {
        }
        public override void Initialize()
        {
            // Size of all the bytes without the dynamic portion
            var BlockLength = 12 + Items.Count * 2 + 1;
            // Add in the dynamic portion
            BlockLength += Items.Aggregate(0, (a, b) =>
            {
                return b.Payload.StringToByteArray().Count();
            });
            //Make encryptable area lie on a 16-byte boundary
            Padding = (BlockLength - 4) % 16;
            if (Padding != 0)
            {
                Padding += 16 - Padding;
                BlockLength += Padding;
            }
        }
        public override string BuildBitString()
        {
            var sb = new StringBuilder();

            sb.Append(Convert.ToString((uint)(Common.SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0'));
            sb.Append(Convert.ToString(Common.MessageType, 2).PadLeft(8, '0'));
            sb.Append(Convert.ToString((uint)(Common.EffectiveTimeStamp & 0xFFFFFF), 2).PadLeft(24, '0'));
            sb.Append(Convert.ToString((byte)0, 2).PadLeft(8, '0'));

            if (Items != null && Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    sb.Append(Convert.ToString((byte)(Items[i].Length & 0xFF), 2).PadLeft(8, '0'));
                    sb.Append(Convert.ToString((byte)(Items[i].Parameter & 0xFF), 2).PadLeft(8, '0'));
                    sb.Append(Items[i].Payload.StringToByteArray().Aggregate(string.Empty, (a, b) => a + Convert.ToString((byte)(b & 0xFF), 2).PadLeft(8, '0')));
                }

                // Add byte with length of 0
                sb.Append("00000000");
            }


            // Add padding
            for (int i = 0; i < Padding; i++)
            {
                sb.Append("00000000");
            }

            sb.Append(Convert.ToString(CRC, 2).PadLeft(32, '0'));

            return sb.ToString();
        }
        public override string ToString()
        {
            return BuildBitString();
        }
    }
}
