using System.Collections.Generic;
using System.Collections.ObjectModel;
using Simulator.ViewModel.Command;
using Simulator.Common.Models;

namespace Simulator.Controls
{
    public class LTEMeasurementViewModel : ViewModelBase
    {
        public LTEMeasurementViewModel(List<LTEMeasurementItem> measurements)
        {
            AddCommand = new DelegateCommand(Add);
            Measurements = measurements;
        }
        public ObservableCollection<LTEItemViewModel> MeasurementItems { get; } = new();
        public List<LTEMeasurementItem> Measurements { get; }
        public DelegateCommand AddCommand { get; }

        public void Add()
        {
            var measurementItem = new LTEMeasurementItem();
            Measurements.Add(measurementItem);
            MeasurementItems.Add(new LTEItemViewModel(measurementItem));
        }
    }
}
