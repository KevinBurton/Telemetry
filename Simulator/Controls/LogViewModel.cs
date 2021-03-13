using Simulator.Common.Models;
using Simulator.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class LogViewModel : ViewModelBase
    {
        readonly Log _log;
        public LogViewModel(Log log)
        {
            _log = log;
            AddCommand = new DelegateCommand(Add);
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
            get => _log.Common.MessageType;
            set
            {
                if (_log.Common.MessageType != value)
                {
                    _log.Common.MessageType = value;
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
        public uint TimeStamp
        {
            get => _log.Common.TimeStamp;
            set
            {
                if (_log.Common.TimeStamp != value)
                {
                    _log.Common.TimeStamp = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("TimeStampBitString");
                }
            }
        }
        public string TimeStampBitString
        {
            get
            {
                return Convert.ToString((uint)(TimeStamp & 0xFFFFFF), 2).PadLeft(24, '0');
            }
        }
        public DelegateCommand AddCommand { get; }
        public void Add()
        {
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
                    RaisePropertyChanged("MessageBitString");
                }
            }
        }
    }
}
