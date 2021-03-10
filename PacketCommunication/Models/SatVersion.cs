using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PacketCommunication.Models
{
    // 123 measurements - 40 with metadata leaves 984 which is 123 measurements
    [StructLayout(LayoutKind.Explicit, Size = 1024)]
    public class SatVersion
    {
        [FieldOffset(0)]
        public UInt32 SerialNumber;

        [FieldOffset(3)]
        public Byte MessageType;

        [FieldOffset(4)]
        public UInt32 TimeStamp;

        [FieldOffset(7)]
        public Byte BatteryVoltage;

        [FieldOffset(7)]
        public Byte FaultCodes;

        [FieldOffset(12)]
        public UInt32[] Measurements;

        [FieldOffset(32)]
        public UInt32 CRC32;

        public UInt32 SerialNumberMask(UInt32 x)
        {
            return (x >> 8) & 0xFFFFFF;
        }
        public UInt32 TimeStampMask(UInt32 x)
        {
            return (x >> 8) & 0xFFFFFF;
        }
        public Byte BatteryVoltageMask(Byte x)
        {
            return (Byte)((x >> 4) & 0xFF);
        }

        public Byte FaultCodeMask(ushort x)
        {
            return (Byte)((x >> 4) & 0xFF);
        }

        public bool MeasurementSAT(UInt32 x)
        {
            return ((x >> 31) & 0x01) != 0 ? true : false;
        }
        public Byte MeasurementGain(UInt32 x)
        {
            return (Byte)((x >> 5) & 0x07);
        }
        public Byte MeasurementType(UInt32 x)
        {
            return (Byte)(x & 0x01F);
        }
        public UInt32 MeasurementValue(UInt32 x)
        {
            return (x >> 1) & 0x7FFFFFFF;
        }

    }
}
