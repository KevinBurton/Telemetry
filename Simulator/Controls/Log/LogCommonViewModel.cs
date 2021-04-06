using Simulator.Common.Models;
using Simulator.Common.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Simulator.Controls
{
    public class LogCommonViewModel : ViewModelBase
    {
        public LogCommonViewModel(LogCommon common)
        {
            Common = common;
        }

        public LogCommon Common { get; }
        public uint SerialNumber
        {
            get => Common.SerialNumber;
            set
            {
                if (Common.SerialNumber != value)
                {
                    Common.SerialNumber = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("SerialNumberBitString");
                }
            }
        }
        public string SerialNumberBitString => Convert.ToString((uint)(SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0');
        public byte MessageType
        {
            get => Common.MessageType;
        }
        public string MessageTypeBitString => Convert.ToString((byte)(MessageType & 0xFFFF), 2).PadLeft(8, '0');

        public uint TimeStamp
        {
            get => Common.TimeStamp;
            set
            {
                if (Common.TimeStamp != value)
                {
                    Common.TimeStamp = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("TimeStampBitString");
                }
            }
        }
        public string TimeStampBitString => Convert.ToString((uint)(TimeStamp & 0xFFFFFF), 2).PadLeft(24, '0');
    }
}
