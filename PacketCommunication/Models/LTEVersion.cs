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
    public class LTEVersion
    {
        [FieldOffset(0)]
        public UInt32 SerialNumber;

        [FieldOffset(4)]
        public UInt32 TimeStamp;

        [FieldOffset(8)]
        public Byte[] GNSS;

        [FieldOffset(15)]
        public Byte FWMajorRev;

        [FieldOffset(16)]
        public Byte FWMinorRev;

        [FieldOffset(17)]
        public Byte FWBuild;

        [FieldOffset(18)]
        public Byte ModemFWMajor;

        [FieldOffset(19)]
        public Byte ModemFWMinor;

        [FieldOffset(20)]
        public Byte ModemFWBuild;

        [FieldOffset(21)]
        public Byte LTEConnectionFailureStatus;

        [FieldOffset(22)]
        public Byte UploadsFailureStatus;

        [FieldOffset(23)]
        public Byte GetMailboxFailureStatus;

        [FieldOffset(24)]
        public Byte GetFirwareFailureStatus;

        // These fields are 12 bits each
        [FieldOffset(25)]
        public ushort BatteryVoltage;
        [FieldOffset(26)]
        public ushort RMSModemCurrent;

        // This is 12 bits also
        [FieldOffset(28)]
        public ushort PeakModemCurrent;

        // These are 2 bi2924)]
        [FieldOffset(29)]
        public Byte TSMFW;
        [FieldOffset(29)]
        public Byte MODFW;

        // This is 3 bytes long
        [FieldOffset(30)]
        public ushort FaultCodes;

        [FieldOffset(32)]
        public UInt32[] Measurements;


        [FieldOffset(1020)]
        public UInt32 CRC32;

        public UInt32 BatteryVoltageMask(UInt32 x)
        {
            return x >> 4;
        }
        public UInt32 RMSModemCurrentMask(UInt32 x)
        {
            return x & 0xFFFFF;
        }
        public UInt32 PeakModemCurrentMask(UInt32 x)
        {
            return x >> 4;
        }
        public Byte TSMFWMask(Byte x)
        {
            return (Byte)((x >> 2) & 0x03);
        }
        public Byte MODFWMask(Byte x)
        {
            return (Byte)(x & 0x03);
        }
        public UInt32 FaultCodeMask(UInt32 x)
        {
            return ((x >> 8) & 0x0FFFFFF);
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
