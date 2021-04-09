using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common
{
    public interface ICloudAddressService
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }
}
