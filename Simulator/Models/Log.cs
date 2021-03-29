using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models
{
    public class Log
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; set; }
        public uint TimeStamp { get; set; }
        public string LogMessage { get; set; }
        public uint CRC { get; set; }
        public int Padding { get; set; }
        public int BlockLength { get; }

        public Log(string logMessage)
        {
            LogMessage = logMessage;
            int rawUtf8Len = Encoding.Default.GetBytes(logMessage).Length;
            // Pad to 16 byte boundary for encoding
            Padding = ((rawUtf8Len + 8) % 16);
            if(Padding != 0)
            {
                Padding = 16 - Padding;
            }
            BlockLength = Padding + 12 + rawUtf8Len;
        }
    }
}
