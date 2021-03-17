using Simulator.Common.Models;
using Simulator.ViewModel.Command;
using System;
using System.Collections.ObjectModel;

namespace Simulator.Controls
{
    public class ConfigViewModel : ViewModelBase
    {
        readonly Config _config;
        public ConfigViewModel(Config config)
        {
            _config = config;
            ConfigCommonViewModel = new ConfigCommonViewModel(config.Common);
            ConfigDetailViewModel = new ConfigDetailViewModel(config.Items);
        }
        public ConfigCommonViewModel ConfigCommonViewModel { get; }
        public ConfigDetailViewModel ConfigDetailViewModel { get; }
    }
}
