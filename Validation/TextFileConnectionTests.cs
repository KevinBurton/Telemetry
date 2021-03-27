using CLI;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace Validation
{
    public class TextFileConnectionTests
    {
        MeasurementBoard board;
        MethodInfo[] methods;
        [SetUp]
        public void Setup()
        {
            var excludedMethods = new string[]
            {
                "GetType",
                "ToString",
                "Equals",
                "GetHashCode"
            };
            var connection = new TestFileConnection("MeasurementTest.txt");
            board = new MeasurementBoard(connection);
            methods = typeof(MeasurementBoard).GetMethods().Where(m => !excludedMethods.Contains(m.Name)).ToArray();
        }
        [Test]
        public void AdcGetOfcTest()
        {
            var result = board.AdcGetOfcCommand();
            Assert.IsTrue(result.IsSuccess);
        }
    }
}
