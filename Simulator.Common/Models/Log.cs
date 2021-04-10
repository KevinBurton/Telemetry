using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Simulator.Common.Models
{
    public class Log : TSMBase
    {
        public LogCommon Common { get; } = new();
        public List<string> Items { get; } = new List<string>();
        public Log()
        {
        }
        public override void Initialize()
        {
            int messageByteCount = Items.Count * 4;
            // Pad to 16 byte boundary for encoding
            Padding = ((messageByteCount * 4 + 8) % 16);
            if (Padding != 0)
            {
                Padding = 16 - Padding;
            }
            AddCrc();
        }
        public override string BuildBitString()
        {
            var sb = new StringBuilder();

            sb.Append(Convert.ToString((uint)(Common.SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0'));
            sb.Append(Convert.ToString(Common.MessageType, 2).PadLeft(8, '0'));
            sb.Append(Convert.ToString((uint)(Common.TimeStamp & 0xFFFFFF), 2).PadLeft(24, '0'));
            sb.Append(Convert.ToString((byte)0, 2).PadLeft(8, '0'));

            if (Items != null && Items.Count > 0)
            {
                for (var i = 0; i < Items.Count; i++)
                {
                    var pad = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    var values = Encoding.ASCII.GetBytes(Items[i]);

                    pad = pad.Select((v,j) => j < values.Count() ? values[j] : v).ToArray();

                    sb.Append(Convert.ToString((byte)(pad[0] & 0xFFFF), 2).PadLeft(8, '0'));
                    sb.Append(Convert.ToString((byte)(pad[1] & 0xFFFF), 2).PadLeft(8, '0'));
                    sb.Append(Convert.ToString((byte)(pad[2] & 0xFFFF), 2).PadLeft(8, '0'));
                    sb.Append(Convert.ToString((byte)(pad[3] & 0xFFFF), 2).PadLeft(8, '0'));
                    sb.Append(Convert.ToString((byte)(pad[4] & 0xFFFF), 2).PadLeft(8, '0'));
                    sb.Append(Convert.ToString((byte)(pad[5] & 0xFFFF), 2).PadLeft(8, '0'));
                    sb.Append(Convert.ToString((byte)(pad[6] & 0xFFFF), 2).PadLeft(8, '0'));
                    sb.Append(Convert.ToString((byte)(pad[7] & 0xFFFF), 2).PadLeft(8, '0'));
                }
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
