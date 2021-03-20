using Simulator.Common.Models;
using Simulator.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class SateliteItemViewModel : ViewModelBase
    {
        public SateliteItemViewModel(SateliteMeasurementItem measurementItem)
        {
            MeasurementItem = measurementItem;
            GainValues = RangeDescription.ObservableCollection();
            SaturationValues = SaturationDescription.ObservableCollection();
            MeasurementTypeValues = MeasurementTypeDescription.ObservableCollection();
        }
        public SateliteMeasurementItem MeasurementItem { get; }
        public ObservableCollection<SaturationDescription> SaturationValues { get; }
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
        public string SATBitString => Convert.ToString((byte)(SAT & 0x1), 2).PadLeft(1, '0');

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
        public string MeasurementBitString => Convert.ToString((uint)(Measurement & 0x7FFFFF), 2).PadLeft(23, '0');

        public ObservableCollection<RangeDescription> GainValues { get; }
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
        public string GainBitString => Convert.ToString((byte)(Gain & 0x7), 2).PadLeft(3, '0');

        public ObservableCollection<MeasurementTypeDescription> MeasurementTypeValues { get; }
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
        public string TypeBitString => Convert.ToString((byte)(Type & 0x1F), 2).PadLeft(5, '0');
    }
}
