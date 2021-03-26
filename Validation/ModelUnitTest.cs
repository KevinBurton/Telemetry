using CLI;
using NUnit.Framework;

namespace Validation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMeasurementBoardCommands()
        {
            var connection = new MeasurementBoardConnection("COM3:");
            var board = new MeasurementBoard(connection);
            var result = board.AdcStartCommand();

            Assert.Pass();
        }
    }
}