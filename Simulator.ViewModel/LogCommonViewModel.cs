using Simulator.Common.DataProviders;
using Simulator.Common.Models;

namespace Simulator.ViewModel
{
    public class LogCommonViewModel : ViewModelBase
    {
        private readonly LogCommon _logCommon;
        private readonly ILogCommonDataProvider _logCommonDataProvider;
        public LogCommonViewModel(LogCommon logCommon, ILogCommonDataProvider logCommonDataProvider)
        {
            _logCommon = logCommon;
            _logCommonDataProvider = logCommonDataProvider;
        }
        public uint SerialNumber
        {
            get => _logCommon.SerialNumber;
            set
            {
                if (_logCommon.SerialNumber != value)
                {
                    _logCommon.SerialNumber = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MessageType
        {
            get => _logCommon.MessageType;
            set
            {
                if (_logCommon.MessageType != value)
                {
                    _logCommon.MessageType = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint TimeStamp
        {
            get => _logCommon.TimeStamp;
            set
            {
                if (_logCommon.TimeStamp != value)
                {
                    _logCommon.TimeStamp = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
    }
}
