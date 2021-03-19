using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.ViewModels
{
    public class MessageTypeDescription : DescriptionBase
    {
        public static ObservableCollection<MessageTypeDescription> ObservableCollection()
        {
            var result = new ObservableCollection<MessageTypeDescription>();
            result.Add(new MessageTypeDescription() { Value = 0, Display = "Reserved" });
            result.Add(new MessageTypeDescription() { Value = 1, Display = "LTE Measurement" });
            result.Add(new MessageTypeDescription() { Value = 2, Display = "Satelite Measurement" });
            result.Add(new MessageTypeDescription() { Value = 3, Display = "Log Structure" });
            result.Add(new MessageTypeDescription() { Value = 4, Display = "Configuration" });
            result.Add(new MessageTypeDescription() { Value = 5, Display = "Unformated 1KB Block" });
            return result;
        }
    }
}
