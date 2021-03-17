using System;
using System.Collections.Generic;
using Utility.DamienG.Security.Cryptography;

namespace Simulator.Common.Models
{
    public class Satelite
    {
        public SateliteCommon Common { get; } = new();
        public List<SateliteMeasurementItem> Items { get; } = new List<SateliteMeasurementItem>()
        {
            new SateliteMeasurementItem(),
            new SateliteMeasurementItem(),
            new SateliteMeasurementItem(),
            new SateliteMeasurementItem(),
            new SateliteMeasurementItem()
        };
        public uint CRC { get; protected set; }
        public int Padding { get; protected set; }
        public int BlockLength { get; protected set; }
        public string BitString { get; protected set; }
        public byte[] Block { get; protected set; }
        public Satelite()
        {
        }
        public void Initialize()
        {
            // Pad to 16 byte boundary for encoding
            Padding = 0;
            BlockLength = 32 + Items.Count * 4;

            AddCrc();
        }
        private void AddCrc()
        {
            var initialString = BuildBitString();
            var message = ConvertToByteArray(initialString.Substring(4));
            CRC = Crc32.Compute(message);
            BitString = BuildBitString();
            Block = ConvertToByteArray(BitString);
        }
        private string BuildBitString()
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
        private byte[] ConvertToByteArray(string inputBitString)
        {
            List<byte> byteList = new List<byte>();
            for (int i = inputBitString.Length - 1; i >= 0; i -= 8)
            {
                string byteString = "";
                for (int j = 0; (i - j) >= 0 && j < 8; j++)
                {
                    byteString = inputBitString[i - j] + byteString;
                }
                if (byteString != "")
                {
                    byteList.Add(Convert.ToByte(byteString, 2));
                }
            }
            return byteList.ToArray();
        }
        public override string ToString()
        {
            return BuildBitString();
        }
    }
}
