﻿using System.IO.Ports;

namespace CLI
{
    public class MeasurementBoardConnection : SerialPort, ICLIConnection
    {
        public MeasurementBoardConnection(string port)
        {
            Port = port;
        }

        public string Port { get; }

        public string Read()
        {
            return "test";
        }
        public void Send(string command)
        {
            System.Diagnostics.Debug.WriteLine(command);
        }
    }
}