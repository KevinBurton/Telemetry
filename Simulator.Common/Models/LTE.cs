using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.DamienG.Security.Cryptography;

namespace Simulator.Common.Models
{
    public class LTE
    {
        public LTECommon Common { get; } = new();
        public List<LTEItem> Items { get; } = new();
        public uint CRC { get; protected set; }
        public int Padding { get; protected set; }
        public int BlockLength { get; protected set; }
        public string BitString { get; protected set; }
        public byte[] Block { get; protected set; }
        public LTE()
        {
        }
        public void Initialize()
        {
            // Pad to 16 byte boundary for encoding
            Padding = (32 + Items.Count * 4) % 16;
            if (Padding != 0)
            {
                Padding = 16 - Padding;
            }
            BlockLength = Padding + 36 + Items.Count * 4;

            AddCrc();
        }
        private void AddCrc()
        {
            var initialString = BuildBitString();
            var message = ConvertToByteArray(initialString.Substring(0, initialString.Length - 4));
            CRC = Crc32.Compute(message);
            BitString = BuildBitString();
            //var splitString = new string(SplitString(BitString).ToArray());
            Block = ConvertToByteArray(BitString);
        }
        private IEnumerable<char> SplitString(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if(i % 4 == 0)
                {
                    yield return '\r';
                    yield return '\n';
                }
                yield return input[i];
            }
        }
        private string BuildBitString()
        {
            var result = "";
            result += Convert.ToString(Common.SerialNumber & 0xFFFFFF).PadLeft(24, '0');
            result += Convert.ToString(Common.MessageType).PadLeft(8, '0');
            //result += "\n";
            result += Convert.ToString(Common.TimeStamp & 0xFFFFFF).PadLeft(24, '0');
            for (int i = 0; i < 8; i++)
            {
                if (i == 0)
                {
                    //result += "\n";
                }
                result += Convert.ToString(Common.GNSS[i]).PadLeft(8, '0');
            }
            result += Convert.ToString(Common.FWMajorRev).PadLeft(8, '0');
            //result += "\n";
            result += Convert.ToString(Common.FWMinorRev).PadLeft(8, '0');
            result += Convert.ToString(Common.FWBuild).PadLeft(8, '0');
            result += Convert.ToString(Common.ModemFWMajor).PadLeft(8, '0');
            result += Convert.ToString(Common.ModemFWMinor).PadLeft(8, '0');
            //result += "\n";
            result += Convert.ToString(Common.ModemFWBuild).PadLeft(8, '0');
            result += Convert.ToString(Common.LTEConnectionFailureStatus).PadLeft(8, '0');
            result += Convert.ToString(Common.UnloadsFailureStatus).PadLeft(8, '0');
            result += Convert.ToString(Common.GetMailboxFailureStatus).PadLeft(8, '0');
            //result += "\n";
            result += Convert.ToString(Common.GetFirmwareFailureStatus).PadLeft(8, '0');
            result += Convert.ToString(Common.BatteryVoltage & 0xFFF).PadLeft(12, '0');
            result += Convert.ToString(Common.RMSModemCurrent & 0xFFF).PadLeft(12, '0');
            //result += "\n";
            result += Convert.ToString(Common.PeakModemCurrent & 0xFFF).PadLeft(12, '0');
            result += Convert.ToString(Common.TSMFW & 0x3).PadLeft(2, '0');
            result += Convert.ToString(Common.MODFW & 0x3).PadLeft(2, '0');
            result += Convert.ToString(Common.FaultCodes).PadLeft(8, '0');
            result += Convert.ToString(0x0).PadLeft(8, '0');
            //result += "\n";
            for (int i = 0; i < Items.Count; i++)
            {
                result += Convert.ToString(Items[i].SAT & 0x1);
                result += Convert.ToString(Items[i].Measurement & 0x7FFFFF).PadLeft(23, '0');
                result += Convert.ToString(Items[i].Gain & 0x7).PadLeft(3, '0');
                result += Convert.ToString(Items[i].Type & 0x1F).PadLeft(5, '0');
                //result += "\n";
            }
            for (int i = 0; i < Padding; i++)
            {
                result += Convert.ToString((byte)0x0).PadLeft(8, '0');
                if ((i + 1) % 4 == 0)
                {
                    //result += "\n";
                }
            }
            result += Convert.ToString(CRC).PadLeft(32, '0');
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
