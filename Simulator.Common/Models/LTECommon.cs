using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.Models
{
    public class LTECommon
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; set; }
        public uint TimeStamp { get; set; }
        public string GNSS { get; set; }
        public byte FWMajorRev { get; set; }
        public byte FWMinorRev { get; set; }
        public byte FWBuild { get; set; }
        public byte ModemFWMajor { get; set; }
        public byte ModemFWMinor { get; set; }
        public byte ModemFWBuild { get; set; }
        public byte LTEConnectionFailureStatus { get; set; }
        public byte UnloadsFailureStatus { get; set; }
        public byte GetMailboxFailureStatus { get; set; }
        public byte GetFirmwareFailureStatus { get; set; }
        public ushort BatteryVoltage { get; set; }
        public ushort RMSModemCurrent { get; set; }
        public ushort PeakModemCurrent { get; set; }
        public byte TSMFW { get; set; }
        public byte MODFW { get; set; }
        public byte FaultCodes { get; set; }
    }
}
