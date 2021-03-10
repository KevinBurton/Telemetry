using System.Collections.Generic;
using Simulator.Common.Models;

namespace Simulator.Common.DataProviders
{
    public interface ILTEDataProvider
    {
        IEnumerable<LTE> LoadLTE();
        void SaveLTE(LTE lte);
    }
}
