using System.Collections.ObjectModel;

namespace Simulator.Common.ViewModels
{
    public class MeasurementTypeDescription : DescriptionBase
    {
        public static ObservableCollection<MeasurementTypeDescription> ObservableCollection()
        {
            var result = new ObservableCollection<MeasurementTypeDescription>();
            result.Add(new MeasurementTypeDescription() { Value = 1, Display = "NativeCoupon VDC" });
            result.Add(new MeasurementTypeDescription() { Value = 2, Display = "NativeCoupon VAC" });
            result.Add(new MeasurementTypeDescription() { Value = 3, Display = "ProtectCoupon VDC" });
            result.Add(new MeasurementTypeDescription() { Value = 4, Display = "ProtectCoupon VAC" });
            result.Add(new MeasurementTypeDescription() { Value = 5, Display = "AcCoupon VDC" });
            result.Add(new MeasurementTypeDescription() { Value = 6, Display = "AcCoupon VAC" });
            result.Add(new MeasurementTypeDescription() { Value = 7, Display = "Stucture 1 VDC" });
            result.Add(new MeasurementTypeDescription() { Value = 8, Display = "Stucture 1 VAC" });
            result.Add(new MeasurementTypeDescription() { Value = 9, Display = "Stucture 2 VDC" });
            result.Add(new MeasurementTypeDescription() { Value = 10, Display = "Stucture 2 VAC" });
            result.Add(new MeasurementTypeDescription() { Value = 11, Display = "Internal Shunt VDC" });
            result.Add(new MeasurementTypeDescription() { Value = 12, Display = "Internal Shunt VAC" });
            result.Add(new MeasurementTypeDescription() { Value = 13, Display = "External Shunt/Aux1 VDC" });
            result.Add(new MeasurementTypeDescription() { Value = 14, Display = "External Shunt/Aux1 VAC" });
            result.Add(new MeasurementTypeDescription() { Value = 15, Display = "Instant Off VDC" });
            result.Add(new MeasurementTypeDescription() { Value = 16, Display = "Instant Off VAC" });
            result.Add(new MeasurementTypeDescription() { Value = 17, Display = "PT100 Degree C" });
            result.Add(new MeasurementTypeDescription() { Value = 18, Display = "Ambient Temp Degree C" });
            result.Add(new MeasurementTypeDescription() { Value = 19, Display = "Ambient Humidity %" });
            result.Add(new MeasurementTypeDescription() { Value = 20, Display = "Accel Peak X G" });
            result.Add(new MeasurementTypeDescription() { Value = 21, Display = "Accel Peak Y G" });
            result.Add(new MeasurementTypeDescription() { Value = 22, Display = "Accel Peak Z G" });
            result.Add(new MeasurementTypeDescription() { Value = 23, Display = "Magnetic Field Str X uT" });
            result.Add(new MeasurementTypeDescription() { Value = 24, Display = "Magnetic Field Str Y uT" });
            result.Add(new MeasurementTypeDescription() { Value = 25, Display = "Magnetic Field Str Z uT" });
            return result;
        }
    }
}
