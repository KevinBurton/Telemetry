using CLI;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Validation
{
    [TestFixture]
    public class ResistanceTests
    {
        delegate ICLICommandResult MeasurementFunction(int n);
        delegate ICLICommandResult MeasurementRelayFunction(MeasurementBoardChannels first, MeasurementBoardChannels second);
    }
}
