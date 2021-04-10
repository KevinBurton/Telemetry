using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator.Common.Models
{
    public class Satelite : TSMBase
    {
        public SateliteCommon Common { get; } = new();
        public List<SateliteMeasurementItem> Items { get; } = new ();
        public Satelite()
        {
        }
        public override void Initialize()
        {
            const int MAX_ITEMS = 5;

            // Make sure we send only 5 measurements
            // Fill in the missing elements
            for(int i = Items.Count; i < MAX_ITEMS; i++)
            {
                Items.Add(new SateliteMeasurementItem());
            }
            // Remove items above 5
            for(int i = MAX_ITEMS; i < Items.Count; i++)
            {
                Items.RemoveAt(i);
            }
            Padding = 0;

            AddCrc();
        }
        public override string BuildBitString()
        {
            var sb = new StringBuilder();

            sb.Append(Convert.ToString((uint)(Common.SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0'));
            sb.Append(Convert.ToString(Common.MessageType, 2).PadLeft(8, '0'));
            sb.Append(Convert.ToString((uint)(Common.TimeStamp & 0xFFFFFF), 2).PadLeft(24, '0'));


            sb.Append(Convert.ToString(Common.BatteryVoltage, 2).PadLeft(8, '0'));
            sb.Append(Convert.ToString(Common.FaultCodes, 2).PadLeft(8, '0'));
            sb.Append(Convert.ToString((uint)0, 2).PadLeft(24, '0'));
            for (int i = 0; i < Items.Count; i++)
            {
                sb.Append(Convert.ToString((byte)(Items[i].SAT & 0x1), 2).PadLeft(1, '0'));
                sb.Append(Convert.ToString((uint)(Items[i].Measurement & 0x7FFFFF), 2).PadLeft(23, '0'));
                sb.Append(Convert.ToString((byte)(Items[i].Gain & 0x7), 2).PadLeft(3, '0'));
                sb.Append(Convert.ToString((byte)(Items[i].Type & 0x1F), 2).PadLeft(5, '0'));
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
