using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class ConfigItemViewModel : ViewModelBase
    {
        private readonly ConfigItem _configItem;
        public ConfigItemViewModel(ConfigItem configItem)
        {
            _configItem = configItem;
        }
        public byte Len
        {
            get => _configItem.Len;
            set
            {
                if (_configItem.Len != value)
                {
                    _configItem.Len = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("LenTypeBitString");
                }
            }
        }
        public string LenBitString
        {
            get
            {
                return Convert.ToString((byte)(Len & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
        public byte MajorType
        {
            get => _configItem.MajorType;
            set
            {
                if (_configItem.MajorType != value)
                {
                    _configItem.MajorType = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MajorTypeBitString");
                }
            }
        }
        public string MajorTypeBitString
        {
            get
            {
                return Convert.ToString((byte)(MajorType & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
        public byte MinorType
        {
            get => _configItem.MinorType;
            set
            {
                if (_configItem.MinorType != value)
                {
                    _configItem.MinorType = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MinorTypeBitString");
                }
            }
        }
        public string MinorTypeBitString
        {
            get
            {
                return Convert.ToString((byte)(MinorType & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
    }
}
