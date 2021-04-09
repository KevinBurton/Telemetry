namespace Validation
{
    public class MeasurementValueParameter
    {
        public float FirstVoltage { get; set; }
        public float SecondVoltage { get; set; }
        public int Count { get; set; }
        
        public object[] Objects
        { 
            get
            {
                return new object[] { FirstVoltage,  SecondVoltage, Count };
            }
        }
    }
}
