using Simulator.Common.DataProviders;
using Simulator.Common.Models;

namespace Simulator.ViewModel
{
    public class LogViewModel : ViewModelBase
    {
        private readonly Log _log;
        private readonly ILogDataProvider _logDataProvider;
        public LogViewModel(Log log, ILogDataProvider logDataProvider)
        {
            _log = log;
            _logDataProvider = logDataProvider;
        }
        public uint SerialNumber
        {
            get => _log.Common.SerialNumber;
            set
            {
                if (_log.Common.SerialNumber != value)
                {
                    _log.Common.SerialNumber = value;
                    RaisePropertyChanged();
                }
            }
        }
        public byte MessageType
        {
            get => _log.Common.MessageType;
            set
            {
                if (_log.Common.MessageType != value)
                {
                    _log.Common.MessageType = value;
                    RaisePropertyChanged();
                }
            }
        }
        public uint TimeStamp
        {
            get => _log.Common.TimeStamp;
            set
            {
                if (_log.Common.TimeStamp != value)
                {
                    _log.Common.TimeStamp = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Message
        {
            get => _log.Message;
            set
            {
                if (_log.Message != value)
                {
                    _log.Message = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
