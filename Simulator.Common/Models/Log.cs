using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.Models
{
    public class Log
    {
        public LogCommon Common { get; }
        public string Message { get; set; }
        public uint CRC { get; protected set; }
        public int Padding { get; protected set; }
        public int BlockLength { get; protected set; }

        public Log(string logMessage)
        {
        }
        public void Initialize()
        {
            int rawUtf8Len = Encoding.Default.GetBytes(Message).Length;
            // Pad to 16 byte boundary for encoding
            Padding = ((rawUtf8Len + 8) % 16);
            if (Padding != 0)
            {
                Padding = 16 - Padding;
            }
            BlockLength = Padding + 12 + rawUtf8Len;
        }
    }
}
