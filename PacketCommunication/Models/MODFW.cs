using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketCommunication.Models
{
    [BitFieldNumberOfBitsAttribute(2)]
    public struct MODFWBitField : IBitField
    {
        [BitFieldInfo(2, 2)]
        public byte MODFW { get; set; }
    }
}
