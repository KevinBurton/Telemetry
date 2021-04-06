using System;

namespace Simulator.Common.Models
{
    public class Unformatted : TSMBase
    {
        public UnformattedCommon Common { get; } = new();
        public Unformatted()
        {
        }
        public override void Initialize()
        {
        }
        public override string BuildBitString()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return BuildBitString();
        }
    }
}
