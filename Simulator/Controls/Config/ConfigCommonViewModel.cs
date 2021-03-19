using Simulator.Common.Models;
using Simulator.Common.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Simulator.Controls
{
    public class ConfigCommonViewModel : ViewModelBase
    {
        public ConfigCommonViewModel(ConfigCommon common)
        {
            Common = common;
            MessageTypeValues = MessageTypeDescription.ObservableCollection();
        }
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
        public string SerialNumberBitString
        {
            get
            {
                return Convert.ToString((uint)(SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0');
            }
        }
        public ObservableCollection<MessageTypeDescription> MessageTypeValues { get; }
        public byte MessageType
        {
            get => Common.MessageType;
            set
            {
                if (Common.MessageType != value)
                {
                    Common.MessageType = value;
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
            get => Common.EffectiveTimeStamp;
            set
            {
                if (Common.EffectiveTimeStamp != value)
                {
                    Common.EffectiveTimeStamp = value;
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

        public ConfigCommon Common { get; }
    }
}
