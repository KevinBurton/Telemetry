﻿using System;
using System.Collections.Generic;
using Utility.DamienG.Security.Cryptography;

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
            // Make sure we send only 5 measurements
            // Fill in the missing elements
            for(int i = Items.Count; i < 5; i++)
            {
                Items.Add(new SateliteMeasurementItem());
            }
            // Remove items above 5
            for(int i = 5; i < Items.Count; i++)
            {
                Items.RemoveAt(i);
            }
            Padding = 0;

            AddCrc();
        }
        public override string BuildBitString()
        {
            var result = "";
            result += Convert.ToString((uint)(Common.SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0');
            result += Convert.ToString(Common.MessageType, 2).PadLeft(8, '0');
            result += Convert.ToString((uint)(Common.TimeStamp & 0xFFFFFF), 2).PadLeft(24, '0');


            result += Convert.ToString(Common.BatteryVoltage, 2).PadLeft(8, '0');
            result += Convert.ToString(Common.FaultCodes, 2).PadLeft(8, '0');
            result += Convert.ToString((uint)0, 2).PadLeft(24, '0');
            for (int i = 0; i < Items.Count; i++)
            {
                result += Convert.ToString((byte)(Items[i].SAT & 0x1), 2).PadLeft(1, '0');
                result += Convert.ToString((uint)(Items[i].Measurement & 0x7FFFFF), 2).PadLeft(23, '0');
                result += Convert.ToString((byte)(Items[i].Gain & 0x7), 2).PadLeft(3, '0');
                result += Convert.ToString((byte)(Items[i].Type & 0x1F), 2).PadLeft(5, '0');
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
