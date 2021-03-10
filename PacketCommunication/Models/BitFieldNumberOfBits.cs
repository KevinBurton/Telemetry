using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketCommunication.Models
{
    /// <summary>
    /// Specifies the number of bits in the bit field structure
    /// Maximum number of bits are 64
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class BitFieldNumberOfBitsAttribute : Attribute
    {
        /// <summary>
        /// Initializes new instance of BitFieldNumberOfBitsAttribute with the specified number of bits
        /// </summary>
        /// <param name="bitCount">The number of bits the bit field will contain (Max 64)</param>
        public BitFieldNumberOfBitsAttribute(byte bitCount)
        {
            if ((bitCount < 1) || (bitCount > 64))
                throw new ArgumentOutOfRangeException("bitCount", bitCount,
                "The number of bits must be between 1 and 64.");

            BitCount = bitCount;
        }

        /// <summary>
        /// The number of bits the bit field will contain
        /// </summary>
        public byte BitCount { get; private set; }
    }
}
