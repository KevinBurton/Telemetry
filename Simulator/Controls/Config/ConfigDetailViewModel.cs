using Simulator.Common.Models;
using Simulator.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class ConfigDetailViewModel : ViewModelBase
    {
        public ConfigDetailViewModel(List<ConfigItem> items)
        {
            Items = items;
            AddCommand = new DelegateCommand(Add);
        }

        public ObservableCollection<ConfigItemViewModel> ConfigItems { get; } = new();
        public List<ConfigItem> Items { get; }

        public DelegateCommand AddCommand { get; }
        public void Add()
        {
            var item = new ConfigItem();
            Items.Add(item);
            ConfigItems.Add(new ConfigItemViewModel(item));
        }
    }
}
