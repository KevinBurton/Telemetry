using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace CLI
{
    public class CLIConnection : SerialPort, ICLIConnection
    {
        public string Port { get; }

        public CLIConnection(string port) : base(port)
        {
            Port = port;
        }
        public void Send(string command)
        {
            if (!IsOpen)
            {
                Open();
            }
            Write(command);
        }
        public IEnumerable<string> Read()
        {
            List<string> response = new List<string>();
            var currentLine = ReadLine();
            while (currentLine != null && currentLine.Length > 0 && currentLine[0] != '.' && currentLine[0] != '!')
            {
                response.Add(currentLine);
                // Read from serial port
                currentLine = ReadLine();
            }
            response.Add(currentLine);
            return response;
        }
    }
}
