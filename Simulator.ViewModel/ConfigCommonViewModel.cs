using Simulator.Common.DataProviders;
using Simulator.Common.Models;

namespace Simulator.ViewModel
{
    public class ConfigCommonViewModel : ViewModelBase
    {
        private readonly ConfigCommon _configCommon;
        private readonly IConfigCommonDataProvider _configCommonDataProvider;
        public ConfigCommonViewModel(ConfigCommon configCommon, IConfigCommonDataProvider configCommonDataProvider)
        {
            _configCommon = configCommon;
            _configCommonDataProvider = configCommonDataProvider;
        }
        public uint SerialNumber
        {
            get => _configCommon.SerialNumber;
            set
            {
                if (_configCommon.SerialNumber != value)
                {
                    _configCommon.SerialNumber = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MessageType
        {
            get => _configCommon.MessageType;
            set
            {
                if (_configCommon.MessageType != value)
                {
                    _configCommon.MessageType = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint EffectiveTimeStamp
        {
            get => _configCommon.EffectiveTimeStamp;
            set
            {
                if (_configCommon.EffectiveTimeStamp != value)
                {
                    _configCommon.EffectiveTimeStamp = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
    }
}
