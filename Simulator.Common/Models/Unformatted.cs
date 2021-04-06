using System;

namespace Simulator.Common.Models
{
    public class Unformatted : TSMBase
    {
        public UnformattedCommon Common { get; } = new();
        public uint CRC { get; protected set; }
        public int Padding { get; protected set; }
        public int BlockLength { get; protected set; }
        public string BitString { get; protected set; }
        public byte[] Block { get; protected set; }
        public Unformatted()
        {
        }
        public void Initialize()
        {
        }
        private void AddCrc()
        {
        }
        private string BuildBitString()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return BuildBitString();
        }
    }
}
