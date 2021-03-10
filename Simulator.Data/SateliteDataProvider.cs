using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;
using System.Collections.Generic;

namespace Simulator.DataAccess
{
    public class SateliteDataProvider : ISateliteDataProvider
    {
        IEnumerable<Satelite> ISateliteDataProvider.LoadSatelite()
        {
            throw new NotImplementedException();
        }

        void ISateliteDataProvider.SaveSatelite(Satelite satelite)
        {
            throw new NotImplementedException();
        }
    }
}
