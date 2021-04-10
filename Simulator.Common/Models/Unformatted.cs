using System;
using System.Text;
using System.Linq;

namespace Simulator.Common.Models
{
    public class Unformatted : TSMBase
    {
        public UnformattedCommon Common { get; } = new();
        public byte[] Data { get; set; }
        public Unformatted()
        {
        }
        public override void Initialize()
        {
            AddCrc();
        }
        public override string BuildBitString()
        {
            var sb = new StringBuilder();
            sb.Append(Convert.ToString((uint)(Common.SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0'));
            sb.Append(Convert.ToString(Common.MessageType, 2).PadLeft(8, '0'));
            sb.Append(Convert.ToString((uint)(Common.TimeStamp & 0xFFFFFF), 2).PadLeft(24, '0'));
            sb.Append(Convert.ToString((byte)0, 2).PadLeft(8, '0'));

            sb.Append(Convert.ToString((ushort)(Data.Length & 0xFFFF), 2).PadLeft(16, '0'));
            
            sb.AppendJoin(null, new byte[1010].Select((v,j) => j < Data.Count() ? Convert.ToString(Data[j], 2).PadLeft(8, '0') : 
                                                                                  Convert.ToString(0, 2).PadLeft(8, '0')));

            sb.Append(Convert.ToString(CRC, 2).PadLeft(32, '0'));
            return sb.ToString();
        }
        public override string ToString()
        {
            return BuildBitString();
        }
    }
}
