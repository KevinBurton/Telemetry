using System;
using System.Collections.Generic;
using System.Text;
using Utility.DamienG.Security.Cryptography;

namespace Simulator.Common.Models
{
    public class Log
    {
        public LogCommon Common { get; } = new();
        public List<string> Items { get; } = new List<string>();
        public uint CRC { get; protected set; }
        public int Padding { get; protected set; }
        public string BitString { get; protected set; }
        public int BlockLength { get; protected set; }
        public byte[] Block { get; protected set; }
        public Log()
        {
        }
        public void Initialize()
        {
            int messageByteCount = Items.Count * 4;
            // Pad to 16 byte boundary for encoding
            Padding = ((messageByteCount * 4 + 8) % 16);
            if (Padding != 0)
            {
                Padding = 16 - Padding;
            }
            BlockLength = Padding + 12 + messageByteCount;
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
            result += Convert.ToString((byte)0, 2).PadLeft(8, '0');

            if (Items != null && Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    var pad = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    var values = Encoding.ASCII.GetBytes(Items[i]);
                    for (int j = 0; j < values.Length && j < pad.Length; j++)
                    {
                        pad[j] = values[j];
                    }
                    result += Convert.ToString((byte)(pad[0] & 0xFFFF), 2).PadLeft(8, '0') +
                              Convert.ToString((byte)(pad[1] & 0xFFFF), 2).PadLeft(8, '0') +
                              Convert.ToString((byte)(pad[2] & 0xFFFF), 2).PadLeft(8, '0') +
                              Convert.ToString((byte)(pad[3] & 0xFFFF), 2).PadLeft(8, '0') +
                              Convert.ToString((byte)(pad[4] & 0xFFFF), 2).PadLeft(8, '0') +
                              Convert.ToString((byte)(pad[5] & 0xFFFF), 2).PadLeft(8, '0') +
                              Convert.ToString((byte)(pad[6] & 0xFFFF), 2).PadLeft(8, '0') +
                              Convert.ToString((byte)(pad[7] & 0xFFFF), 2).PadLeft(8, '0');
                }
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
