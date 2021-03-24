using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.ViewModels
{
    public class SaturationDescription : DescriptionBase
    {
        public static ObservableCollection<SaturationDescription> ObservableCollection()
        {
            var result = new ObservableCollection<SaturationDescription>();
            result.Add(new SaturationDescription() { Value = 0, Display = "No Saturation" });
            result.Add(new SaturationDescription() { Value = 1, Display = "Positive Saturation" });
            result.Add(new SaturationDescription() { Value = 2, Display = "Negative Saturation" });
            result.Add(new SaturationDescription() { Value = 3, Display = "EOM" });
            return result;
        }
    }
}
