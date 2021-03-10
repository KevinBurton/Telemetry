using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.Models
{
    public class LogCommon
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; set; }
        public uint TimeStamp { get; set; }
    }
}
