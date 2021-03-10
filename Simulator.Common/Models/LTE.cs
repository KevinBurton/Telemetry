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
        public uint SerialNumber { get; set; }
        public byte MessageType { get; set; }
        public uint TimeStamp { get; set; }
        public byte[] GNSS { get; set; }
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
        public uint[] Measurements { get; set; }
        public uint CRC { get; protected set; }
        public int Padding { get; }
        public int BlockLength { get; }
        public string BitString { get; protected set; }
        public byte[] Block { get; protected set; }
        public LTE(int n)
        {
            Measurements = new uint[n];
            GNSS = new byte[8];
            // Pad to 16 byte boundary for encoding
            Padding = (32 + n * 4) % 16;
            if(Padding != 0)
            {
                Padding = 16 - Padding;
            }
            BlockLength = Padding + 36 + n * 4;
        }
        public void AddCrc()
        {
            var initialString = BuildBitString();
            var message = ConvertToByteArray(initialString.Substring(0, initialString.Length - 4));
            CRC = Crc32.Compute(message);
            BitString = BuildBitString();
            //var splitString = new string(SplitString(BitString).ToArray());
            Block = ConvertToByteArray(BitString);
        }
        IEnumerable<char> SplitString(string input)
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
            result += Convert.ToString(SerialNumber & 0xFFFFFF).PadLeft(24, '0');
            result += Convert.ToString(MessageType).PadLeft(8, '0');
            //result += "\n";
            result += Convert.ToString(TimeStamp & 0xFFFFFF).PadLeft(24, '0');
            for (int i = 0; i < 8; i++)
            {
                if (i == 0)
                {
                    //result += "\n";
                }
                result += Convert.ToString(GNSS[i]).PadLeft(8, '0');
            }
            result += Convert.ToString(FWMajorRev).PadLeft(8, '0');
            //result += "\n";
            result += Convert.ToString(FWMinorRev).PadLeft(8, '0');
            result += Convert.ToString(FWBuild).PadLeft(8, '0');
            result += Convert.ToString(ModemFWMajor).PadLeft(8, '0');
            result += Convert.ToString(ModemFWMinor).PadLeft(8, '0');
            //result += "\n";
            result += Convert.ToString(ModemFWBuild).PadLeft(8, '0');
            result += Convert.ToString(LTEConnectionFailureStatus).PadLeft(8, '0');
            result += Convert.ToString(UnloadsFailureStatus).PadLeft(8, '0');
            result += Convert.ToString(GetMailboxFailureStatus).PadLeft(8, '0');
            //result += "\n";
            result += Convert.ToString(GetFirmwareFailureStatus).PadLeft(8, '0');
            result += Convert.ToString(BatteryVoltage & 0xFFF).PadLeft(12, '0');
            result += Convert.ToString(RMSModemCurrent & 0xFFF).PadLeft(12, '0');
            //result += "\n";
            result += Convert.ToString(PeakModemCurrent & 0xFFF).PadLeft(12, '0');
            result += Convert.ToString(TSMFW & 0x3).PadLeft(2, '0');
            result += Convert.ToString(MODFW & 0x3).PadLeft(2, '0');
            result += Convert.ToString(FaultCodes).PadLeft(8, '0');
            result += Convert.ToString(0x0).PadLeft(8, '0');
            //result += "\n";
            for (int i = 0; i < Measurements.Length; i++)
            {
                result += Convert.ToString(Measurements[i]).PadLeft(32, '0');
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
