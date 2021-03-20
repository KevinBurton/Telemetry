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
        public byte Length
        {
            get => _configItem.Length;
            set
            {
                if (_configItem.Length != value)
                {
                    _configItem.Length = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("LengthBitString");
                }
            }
        }
        public string LengthBitString => Convert.ToString((byte)(Length & 0xFF), 2).PadLeft(8, '0');

        public byte Parameter
        {
            get => _configItem.Parameter;
            set
            {
                if (_configItem.Parameter != value)
                {
                    _configItem.Parameter = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("ParameterBitString");
                }
            }
        }
        public string ParameterBitString => Convert.ToString((byte)(Parameter & 0xFF), 2).PadLeft(8, '0');

        public byte Payload
        {
            get => _configItem.Payload;
            set
            {
                if (_configItem.Payload != value)
                {
                    _configItem.Payload = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("PayloadBitString");
                }
            }
        }
        public string PayloadBitString => Convert.ToString((byte)(Payload & 0xFF), 2).PadLeft(8, '0');
    }
}
