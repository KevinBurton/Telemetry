using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            get => _log.SerialNumber;
            set
            {
                if (_log.SerialNumber != value)
                {
                    _log.SerialNumber = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MessageType
        {
            get => _log.MessageType;
            set
            {
                if (_log.MessageType != value)
                {
                    _log.MessageType = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint TimeStamp
        {
            get => _log.TimeStamp;
            set
            {
                if (_log.TimeStamp != value)
                {
                    _log.TimeStamp = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
    }
}
