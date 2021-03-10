using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.ViewModel
{
    public class SateliteViewModel : ViewModelBase
    {
        private readonly Satelite _satelite;
        private readonly ISateliteDataProvider _sateliteDataProvider;
        public SateliteViewModel(Satelite satelite, ISateliteDataProvider sateliteDataProvider)
        {
            _satelite = satelite;
            _sateliteDataProvider = sateliteDataProvider;
        }
        public uint SerialNumber
        {
            get => _satelite.SerialNumber;
            set
            {
                if (_satelite.SerialNumber != value)
                {
                    _satelite.SerialNumber = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MessageType
        {
            get => _satelite.MessageType;
            set
            {
                if (_satelite.MessageType != value)
                {
                    _satelite.MessageType = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint TimeStamp
        {
            get => _satelite.TimeStamp;
            set
            {
                if (_satelite.TimeStamp != value)
                {
                    _satelite.TimeStamp = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte BatteryVoltage
        {
            get => _satelite.BatteryVoltage;
            set
            {
                if (_satelite.BatteryVoltage != value)
                {
                    _satelite.BatteryVoltage = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FaultCodes
        {
            get => _satelite.FaultCodes;
            set
            {
                if (_satelite.FaultCodes != value)
                {
                    _satelite.FaultCodes = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint[] Measurements
        {
            get => _satelite.Measurements;
            set
            {
                if (_satelite.Measurements != value)
                {
                    _satelite.Measurements = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
    }
}
