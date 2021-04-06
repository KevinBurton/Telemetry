using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator.Common.Models
{
    public class LTE : TSMBase
    {
        public LTECommon Common { get; } = new();
        public List<LTEMeasurementItem> Items { get; } = new();
        public LTE()
        {
        }
        public override void Initialize()
        {
            // Pad to 16 byte boundary for encoding
            Padding = (32 + Items.Count * 4) % 16;
            if (Padding != 0)
            {
                Padding = 16 - Padding;
            }

            AddCrc();
        }
        public override string BuildBitString()
        {
            var result = "";
            result += Convert.ToString((uint)(Common.SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0');
            result += Convert.ToString(Common.MessageType, 2).PadLeft(8, '0');
            result += Convert.ToString((uint)(Common.TimeStamp & 0xFFFFFF), 2).PadLeft(24, '0');

            var pad = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            if (Common.GNSS != null)
            {
                var values = Encoding.ASCII.GetBytes(Common.GNSS);
                for (int i = 0; i < values.Length && i < pad.Length; i++)
                {
                    pad[i] = values[i];
                }
            }
            result += Convert.ToString((byte)(pad[0] & 0xFFFF), 2).PadLeft(8, '0');
            result += Convert.ToString((byte)(pad[1] & 0xFFFF), 2).PadLeft(8, '0') +
                      Convert.ToString((byte)(pad[2] & 0xFFFF), 2).PadLeft(8, '0') +
                      Convert.ToString((byte)(pad[3] & 0xFFFF), 2).PadLeft(8, '0') +
                      Convert.ToString((byte)(pad[4] & 0xFFFF), 2).PadLeft(8, '0');
            result += Convert.ToString((byte)(pad[5] & 0xFFFF), 2).PadLeft(8, '0') +
                      Convert.ToString((byte)(pad[6] & 0xFFFF), 2).PadLeft(8, '0') +
                      Convert.ToString((byte)(pad[7] & 0xFFFF), 2).PadLeft(8, '0');

            result += Convert.ToString(Common.FWMajorRev, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.FWMinorRev, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.FWBuild, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.ModemFWMajor, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.ModemFWMinor, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.ModemFWBuild, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.LTEConnectionFailureStatus, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.UnloadsFailureStatus, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.GetMailboxFailureStatus, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.GetFirmwareFailureStatus, 2).PadLeft(8, '0');
            result += Convert.ToString((ushort)(Common.BatteryVoltage & 0xFFF), 2).PadLeft(12, '0');
            result += Convert.ToString((ushort)(Common.RMSModemCurrent & 0xFFF), 2).PadLeft(12, '0');
            result += Convert.ToString((ushort)(Common.PeakModemCurrent & 0xFFF), 2).PadLeft(12, '0');
            result += Convert.ToString((byte)(Common.TSMFW & 0x3), 2).PadLeft(2, '0');
            result += Convert.ToString((byte)(Common.MODFW & 0x3), 2).PadLeft(2, '0');
            result += Convert.ToString(Common.FaultCodes, 2).PadLeft(8, '0');
            result += Convert.ToString(0x0, 2).PadLeft(8, '0');
            for (int i = 0; i < Items.Count; i++)
            {
                result += Convert.ToString((byte)(Items[i].SAT & 0x1), 2).PadLeft(1, '0');
                result += Convert.ToString((uint)(Items[i].Measurement & 0x7FFFFF), 2).PadLeft(23, '0');
                result += Convert.ToString((byte)(Items[i].Gain & 0x7), 2).PadLeft(3, '0');
                result += Convert.ToString((byte)(Items[i].Type & 0x1F), 2).PadLeft(5, '0');
            }

            //Add the EOM indicator
            result += "100000000000000000000011";

            for (int i = 0; i < Padding; i++)
            {
                result += Convert.ToString((byte)0x0, 2).PadLeft(8, '0');
                if ((i + 1) % 4 == 0)
                {
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
