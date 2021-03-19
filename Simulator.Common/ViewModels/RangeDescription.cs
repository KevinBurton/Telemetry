using System.Collections.ObjectModel;

namespace Simulator.Common.ViewModels
{
    public class RangeDescription : DescriptionBase
    {
        public static ObservableCollection<RangeDescription> ObservableCollection()
        {
            var result = new ObservableCollection<RangeDescription>();
            result.Add(new RangeDescription() { Value = 0, Display = "0.187" });
            result.Add(new RangeDescription() { Value = 1, Display = "0.350" });
            result.Add(new RangeDescription() { Value = 2, Display = "0.425" });
            result.Add(new RangeDescription() { Value = 3, Display = "2.572" });
            result.Add(new RangeDescription() { Value = 4, Display = "3.857" });
            result.Add(new RangeDescription() { Value = 5, Display = "12.080" });
            result.Add(new RangeDescription() { Value = 5, Display = "35.420" });
            result.Add(new RangeDescription() { Value = 5, Display = "187.487" });
            return result;
        }
    }
}
