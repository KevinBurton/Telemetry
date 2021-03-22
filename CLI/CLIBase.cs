using System;
using System.IO.Ports;

namespace CLI
{
    public class CLIBase : SerialPort, ICLI
    {
        public virtual void Open(string port)
        {
            throw new NotImplementedException("Open base implementation");
        }
        public new virtual void Close()
        {
            base.Close();
            throw new NotImplementedException("Close base implementation");
        }
        public virtual void Send(ICliCommandSend command)
        {
            throw new NotImplementedException("Send base implementation");
        }
        public virtual ICLICommandReceive Receive()
        {
            throw new NotImplementedException("Receive base implementation");
        }
    }
}
