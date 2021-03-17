using Simulator.Common.Models;
using Simulator.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class LogViewModel : ViewModelBase
    {
        readonly Log _log;
        public LogViewModel(Log log)
        {
            _log = log;
            LogCommonViewModel = new LogCommonViewModel(log.Common);
            LogMessageViewModel = new LogMessageViewModel(log.Items);
        }
        public LogCommonViewModel LogCommonViewModel { get; }
        public LogMessageViewModel LogMessageViewModel { get; }
    }
}
