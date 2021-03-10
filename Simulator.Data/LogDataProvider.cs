using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;
using System.Collections.Generic;

namespace Simulator.DataAccess
{
    public class LogDataProvider : ILogDataProvider
    {
        IEnumerable<Log> ILogDataProvider.LoadLog()
        {
            throw new NotImplementedException();
        }

        void ILogDataProvider.SaveLog(Log log)
        {
            throw new NotImplementedException();
        }
    }
}
