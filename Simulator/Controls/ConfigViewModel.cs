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
            AddCommand = new DelegateCommand(Add);
        }
        public uint SerialNumber
        {
            get => _config.Common.SerialNumber;
            set
            {
                if (_config.Common.SerialNumber != value)
                {
                    _config.Common.SerialNumber = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("SerialNumberBitString");
                }
            }
        }
        public string SerialNumberBitString
        {
            get
            {
                return Convert.ToString((uint)(SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0');
            }
        }
        public byte MessageType
        {
            get => _config.Common.MessageType;
            set
            {
                if (_config.Common.MessageType != value)
                {
                    _config.Common.MessageType = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MessageTypeBitString");
                }
            }
        }
        public string MessageTypeBitString
        {
            get
            {
                return Convert.ToString((byte)(MessageType & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
        public uint EffectiveTimeStamp
        {
            get => _config.Common.EffectiveTimeStamp;
            set
            {
                if (_config.Common.EffectiveTimeStamp != value)
                {
                    _config.Common.EffectiveTimeStamp = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("EffectiveTimeStampBitString");
                }
            }
        }
        public string EffectiveTimeStampBitString
        {
            get
            {
                return Convert.ToString((uint)(EffectiveTimeStamp & 0xFFFFFF), 2).PadLeft(24, '0');
            }
        }
        public ObservableCollection<ConfigItemViewModel> ConfigItems { get; } = new();

        private ConfigItemViewModel _selectedConfigItem;
        public ConfigItemViewModel SelectedConfigItem
        {
            get => _selectedConfigItem;
            set
            {
                if (_selectedConfigItem != value)
                {
                    _selectedConfigItem = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsConfigItemSelected));
                }
            }
        }

        public bool IsConfigItemSelected => SelectedConfigItem != null;
        public DelegateCommand AddCommand { get; }
        public void Add()
        {
            ConfigItems.Add(new ConfigItemViewModel(new ConfigItem()));
        }
        public ConfigItem AddItem()
        {
            var item = new ConfigItem();
            _config.Items.Add(item);
            return item;
        }
    }
}
