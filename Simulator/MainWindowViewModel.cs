using Simulator.Common.Models;
using Simulator.Controls;
using Simulator.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            LTEViewModel = new LTEViewModel(lteModel);
            SateliteViewModel = new SateliteViewModel(sateliteModel);
            LogViewModel = new LogViewModel(logModel);
            ConfigViewModel = new ConfigViewModel(configModel);
            SendCommand = new DelegateCommand(Send);
        }

        LTE lteModel = new();
        Satelite sateliteModel = new();
        Log logModel = new();
        Config configModel = new();

        public LTEViewModel LTEViewModel { get; }
        public SateliteViewModel SateliteViewModel { get; }
        public LogViewModel LogViewModel { get; }
        public ConfigViewModel ConfigViewModel { get; }
        public DelegateCommand SendCommand { get; }
        public void Send()
        {
        }
    }
}
