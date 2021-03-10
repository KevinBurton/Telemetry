using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
        private readonly Config _config;
        private readonly IConfigDataProvider _configDataProvider;
        public ConfigViewModel(Config config, IConfigDataProvider configDataProvider)
        {
            _config = config;
            _configDataProvider = configDataProvider;
        }
        public uint SerialNumber
        {
            get => _config.SerialNumber;
            set
            {
                if (_config.SerialNumber != value)
                {
                    _config.SerialNumber = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MessageType
        {
            get => _config.MessageType;
            set
            {
                if (_config.MessageType != value)
                {
                    _config.MessageType = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint EffectiveTimeStamp
        {
            get => _config.EffectiveTimeStamp;
            set
            {
                if (_config.EffectiveTimeStamp != value)
                {
                    _config.EffectiveTimeStamp = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
    }
}
