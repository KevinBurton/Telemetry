using System;
using System.IO.Ports;

namespace CLI
{
    public class MeasurementBoard : ICLI
    {
        public MeasurementBoard(ICLIConnection connection)
        {
            Connection = connection;
        }

        public ICLIConnection Connection { get; }
        public ICLICommandResult Command(ICLICommand command)
        {
            if (!typeof(ICLICommand).IsAssignableFrom(typeof(IMeasurementBoardCommand)))
            {
                throw new ArgumentException(nameof(command));
            }
            throw new NotImplementedException();
        }
    }
}
