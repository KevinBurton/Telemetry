using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;
using System.Collections.Generic;

namespace Simulator.DataAccess
{
    public class ConfigDataProvider : IConfigDataProvider
    {
        IEnumerable<Config> IConfigDataProvider.LoadConfig()
        {
            throw new NotImplementedException();
        }

        void IConfigDataProvider.SaveConfig(Config config)
        {
            throw new NotImplementedException();
        }
    }
}
