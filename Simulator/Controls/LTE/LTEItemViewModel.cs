using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class LTEItemViewModel : ViewModelBase
    {
        public LTEItemViewModel(LTEMeasurementItem measurementItem)
        {
            MeasurementItem = measurementItem;
        }
        public LTEMeasurementItem MeasurementItem { get; }
        public byte SAT
        {
            get => MeasurementItem.SAT;
            set
            {
                if (MeasurementItem.SAT != value)
                {
                    MeasurementItem.SAT = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("SATBitString");
                }
            }
        }
        public string SATBitString
        {
            get
            {
                return Convert.ToString((byte)(SAT & 0x1), 2).PadLeft(1, '0');
            }
        }
        public uint Measurement
        {
            get => MeasurementItem.Measurement;
            set
            {
                if (MeasurementItem.Measurement != value)
                {
                    MeasurementItem.Measurement = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MeasurementBitString");
                }
            }
        }
        public string MeasurementBitString
        {
            get
            {
                return Convert.ToString((uint)(Measurement & 0x7FFFFF), 2).PadLeft(23, '0');
            }
        }
        public byte Gain
        {
            get => MeasurementItem.Gain;
            set
            {
                if (MeasurementItem.Gain != value)
                {
                    MeasurementItem.Gain = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("GainBitString");
                }
            }
        }
        public string GainBitString
        {
            get
            {
                return Convert.ToString((byte)(Gain & 0x7), 2).PadLeft(3, '0');
            }
        }
        public byte Type
        {
            get => MeasurementItem.Type;
            set
            {
                if (MeasurementItem.Type != value)
                {
                    MeasurementItem.Type = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("TypeBitString");
                }
            }
        }
        public string TypeBitString
        {
            get
            {
                return Convert.ToString((byte)(Type & 0x1F), 2).PadLeft(5, '0');
            }
        }
    }
}
