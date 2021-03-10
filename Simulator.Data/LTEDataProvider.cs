using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;
using System.Collections.Generic;

namespace Simulator.Data
{
    public class LTEDataProvider : ILTEDataProvider
    {
        IEnumerable<LTE> ILTEDataProvider.LoadLTE()
        {
            throw new NotImplementedException();
        }

        void ILTEDataProvider.SaveLTE(LTE lte)
        {
            throw new NotImplementedException();
        }
    }
}
