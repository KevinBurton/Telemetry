using Simulator.Common.Models;
using Simulator.ViewModel.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Simulator.Controls
{
    public class SateliteMeasurementViewModel : ViewModelBase
    {
        public SateliteMeasurementViewModel(List<SateliteMeasurementItem> measurements)
        {
            AddCommand = new DelegateCommand(Add);
            Measurements = measurements;
        }
        public ObservableCollection<SateliteItemViewModel> MeasurementItems { get; } = new();
        public List<SateliteMeasurementItem> Measurements { get; }
        public DelegateCommand AddCommand { get; }

        public void Add()
        {
            var measurementItem = new SateliteMeasurementItem();
            Measurements.Add(measurementItem);
            MeasurementItems.Add(new SateliteItemViewModel(measurementItem));
        }
    }
}
