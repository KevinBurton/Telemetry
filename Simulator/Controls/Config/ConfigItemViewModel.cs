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
                    RaisePropertyChanged("LenBitString");
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
        public byte Major
        {
            get => _configItem.MajorType;
            set
            {
                if (_configItem.MajorType != value)
                {
                    _configItem.MajorType = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MajorBitString");
                }
            }
        }
        public string MajorBitString
        {
            get
            {
                return Convert.ToString((byte)(Major & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
        public byte Minor
        {
            get => _configItem.MinorType;
            set
            {
                if (_configItem.MinorType != value)
                {
                    _configItem.MinorType = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MinorBitString");
                }
            }
        }
        public string MinorBitString
        {
            get
            {
                return Convert.ToString((byte)(Minor & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
    }
}
