using System.Collections.Generic;

namespace Simulator.Common.Models
{
    public class Satelite
    {
        public SateliteCommon Common { get; } = new();
        public List<SateliteItem> Items { get; } = new List<SateliteItem>()
        {
            new SateliteItem(),
            new SateliteItem(),
            new SateliteItem(),
            new SateliteItem(),
            new SateliteItem()
        };
        public uint CRC { get; set; }
        public Satelite()
        {
        }
    }
}
