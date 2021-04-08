using System.Collections.Generic;

namespace CLI
{
    public interface ICLIConnection
    {
        public IEnumerable<string> Read();
        public void Send(string values);
    }
}
