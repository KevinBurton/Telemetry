﻿using Simulator.Common.Models;
using Simulator.Controls;
using Simulator.ViewModel.Command;

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
            SendSateliteCommand = new DelegateCommand(SendSatelite);
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
        public DelegateCommand SendSateliteCommand { get; }
        public void Send()
        {
            lteModel.Initialize();
            sateliteModel.Initialize();

            System.Diagnostics.Debug.WriteLine("Sending LTE");
        }
        public void SendSatelite()
        {
            sateliteModel.Initialize();

            System.Diagnostics.Debug.WriteLine("Sending Satelite");
        }
    }
}
