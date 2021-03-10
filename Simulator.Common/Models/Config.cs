using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.Models
{
    public class ConfigSpecification
    {
        public byte Len { get; set; }
        public byte MajorType { get; set; }
        public byte MinorType { get; set; }
    }
    public class Config
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; set; }
        public uint EffectiveTimeStamp { get; set; }
        public ConfigSpecification[] Detail { get; set; }
        public uint CRC { get; set; }
        public int Padding { get; }
        public int BlockLength { get; }
        public Config(ConfigSpecification[] detail)
        {
            Detail = detail;
            Padding = (detail.Length + 8) % 16;
            if(Padding != 0)
            {
                Padding += 16 - Padding;
            }
            BlockLength = Padding + 12 + detail.Length * 4;
        }
    }
}
