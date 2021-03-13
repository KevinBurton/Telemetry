using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            LTEViewModel = new LTEViewModel(new Common.Models.LTECommon());
            SateliteViewModel = new SateliteViewModel(new Common.Models.SateliteCommon());
        }
        public SateliteViewModel SateliteViewModel { get; }
        public ConfigViewModel ConfigViewModel { get; }
        public LogViewModel LogViewModel { get; }
        public LTEViewModel LTEViewModel { get; }
    }
}
