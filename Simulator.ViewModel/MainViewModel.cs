using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ConfigViewModel ConfigCommonViewModel { get; }
        public ConfigViewModel ConfigViewModel { get; }
        public LogViewModel LogViewModel { get; }
        public LTEViewModel LTEViewModel { get; }
        public SateliteViewModel SateliteViewModel { get; }
    }
}
