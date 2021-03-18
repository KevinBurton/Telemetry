using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class SateliteViewModel : ViewModelBase
    {
        public SateliteViewModel(Satelite satelite)
        {
            Satelite = satelite;
            SateliteCommonViewModel = new SateliteCommonViewModel(satelite.Common);
            SateliteMeasurementViewModel = new SateliteMeasurementViewModel(satelite.Items);
        }

        public Satelite Satelite { get; }
        public SateliteCommonViewModel SateliteCommonViewModel { get; }
        public SateliteMeasurementViewModel SateliteMeasurementViewModel { get; }
    }
}
