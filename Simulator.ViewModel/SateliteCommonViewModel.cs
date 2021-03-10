using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.ViewModel
{
    public class SateliteCommonViewModel : ViewModelBase
    {
        private readonly SateliteCommon _sateliteCommon;
        private readonly ISateliteCommonDataProvider _sateliteCommonDataProvider;
        public SateliteCommonViewModel(SateliteCommon sateliteCommon, ISateliteCommonDataProvider sateliteCommonDataProvider)
        {
            _sateliteCommon = sateliteCommon;
            _sateliteCommonDataProvider = sateliteCommonDataProvider;
        }
        public uint SerialNumber
        {
            get => _sateliteCommon.SerialNumber;
            set
            {
                if (_sateliteCommon.SerialNumber != value)
                {
                    _sateliteCommon.SerialNumber = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MessageType
        {
            get => _sateliteCommon.MessageType;
            set
            {
                if (_sateliteCommon.MessageType != value)
                {
                    _sateliteCommon.MessageType = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint TimeStamp
        {
            get => _sateliteCommon.TimeStamp;
            set
            {
                if (_sateliteCommon.TimeStamp != value)
                {
                    _sateliteCommon.TimeStamp = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte BatteryVoltage
        {
            get => _sateliteCommon.BatteryVoltage;
            set
            {
                if (_sateliteCommon.BatteryVoltage != value)
                {
                    _sateliteCommon.BatteryVoltage = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FaultCodes
        {
            get => _sateliteCommon.FaultCodes;
            set
            {
                if (_sateliteCommon.FaultCodes != value)
                {
                    _sateliteCommon.FaultCodes = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
    }
}
