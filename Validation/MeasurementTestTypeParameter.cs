using CLI;

namespace Validation
{
    public class MeasurementTestTypeParameter
    {
        public string Description { get; set; }
        public int Dac0 { get; set; }
        public int Channel0 { get; set; }
        public int Dac1 { get; set; }
        public int Channel1 { get; set; }
        public MeasurementBoardChannels MeasurementBoardChannel0 { get; set; }
        public MeasurementBoardChannels MeasurementBoardChannel1 { get; set; }
        public object[] Objects
        { 
            get
            {
                return new object[] { Description,  Dac0, Channel0, Dac1, Channel1, MeasurementBoardChannel0, MeasurementBoardChannel1 };
            }
        }
    }
}
