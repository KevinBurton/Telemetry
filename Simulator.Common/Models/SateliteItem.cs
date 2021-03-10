using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.Models
{
    public class SateliteItem
    {
        public byte SAT { get; set; }
        public uint Measurement { get; set; }
        public byte Gain { get; set; }
        public byte Type { get; set; }
    }
}
