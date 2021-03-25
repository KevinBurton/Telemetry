using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class MeasurementBoardConnection : ICLIConnection
    {
        public ICLICommandResult Read()
        {
            return new MeasurementBoardCommandResult("test");
        }
        public void Send(string command)
        {
            System.Diagnostics.Debug.WriteLine(command);
        }
    }
}
