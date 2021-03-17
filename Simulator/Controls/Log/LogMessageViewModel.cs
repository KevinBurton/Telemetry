using Simulator.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class LogMessageViewModel : ViewModelBase
    {
        public LogMessageViewModel(List<string> messages)
        {
            AddCommand = new DelegateCommand(Add);
            Messages = messages;
        }

        public List<string> Messages { get; }
        public ObservableCollection<LogItemViewModel> MeasurementItems { get; } = new();
        public DelegateCommand AddCommand { get; }

        public void Add()
        {
            Messages.Add("");
            MeasurementItems.Add(new LogItemViewModel(""));
        }
    }
}
