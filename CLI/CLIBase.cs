using System;
using System.IO.Ports;

namespace CLI
{
    public class CLIBase : SerialPort, ICLI
    {
        public virtual void Send(ICliCommandSend command)
        {
            throw new NotImplementedException("Send base implementation");
        }
    }
}
