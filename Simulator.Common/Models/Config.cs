using System.Collections.Generic;

namespace Simulator.Common.Models
{
    public class Config
    {
        public ConfigCommon Common { get; } = new();
        public List<ConfigItem> Items { get; } = new();
        public uint CRC { get; protected set; }
        public int Padding { get; protected set; }
        public int BlockLength { get; protected set; }
        public Config()
        {
        }
        public void Initialize()
        {
            Padding = (Items.Count + 8) % 16;
            if (Padding != 0)
            {
                Padding += 16 - Padding;
            }
            BlockLength = Padding + 12 + Items.Count * 4;
        }
    }
}
