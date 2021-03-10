using Simulator.Common.DataProviders;
using Simulator.Common.Models;

namespace Simulator.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
        private readonly Config _config;
        private readonly IConfigCommonDataProvider _configCommonDataProvider;
        public ConfigViewModel(Config config, IConfigCommonDataProvider configCommonDataProvider)
        {
            _config = config;
            _configCommonDataProvider = configCommonDataProvider;
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
                }
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
                }
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
                }
            }
        }
        public ConfigItem AddItem()
        {
            var item = new ConfigItem();
            _config.Items.Add(item);
            return item;
        }
    }
}
