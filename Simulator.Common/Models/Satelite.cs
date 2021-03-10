using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.Models
{
    public class Satelite
    {
        SateliteCommon Common { get; }
        List<SateliteItem> Items { get; }
        public uint CRC { get; set; }
        public Satelite()
        {
        }
    }
}
