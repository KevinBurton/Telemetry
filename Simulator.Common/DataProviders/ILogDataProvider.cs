using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.DataProviders
{
    public interface ILogDataProvider
    {
        IEnumerable<Log> LoadLog();
        void SaveLog(Log log);
    }
}
