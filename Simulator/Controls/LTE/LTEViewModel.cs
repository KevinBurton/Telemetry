using Simulator.Common.Models;

namespace Simulator.Controls
{
    public class LTEViewModel : ViewModelBase
    {
        readonly LTE _lte;
        public LTEViewModel(LTE lte)
        {
            _lte = lte;
            LTECommonViewModel = new LTECommonViewModel(lte.Common);
            LTEMeasurementViewModel = new LTEMeasurementViewModel(lte.Items);
        }
        public LTECommonViewModel LTECommonViewModel { get; }
        public LTEMeasurementViewModel LTEMeasurementViewModel { get; }
    }
}
