using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.DataProviders
{
    public interface IConfigDataProvider
    {
        IEnumerable<Config> LoadConfig();
        void SaveConfig(Config config);
    }
}
