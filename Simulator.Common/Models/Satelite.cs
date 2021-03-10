using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.Models
{
    public class Satelite
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; set; }
        public uint TimeStamp { get; set; }
        public byte BatteryVoltage { get; set; }
        public byte FaultCodes { get; set; }
        public uint[] Measurements { get; set; }
        public uint CRC { get; set; }
        public Satelite()
        {
            Measurements = new uint[5];
        }
    }
}
