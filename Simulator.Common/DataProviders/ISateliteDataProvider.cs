using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.DataProviders
{
    public interface ISateliteDataProvider
    {
        IEnumerable<Satelite> LoadSatelite();
        void SaveSatelite(Satelite satelite);
    }
}
