using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Args
{
    public class ArgsBase : ICLICommandArgs
    {
        public ArgsBase(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
