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
            var connection = new MeasurementBoardConnection();
            var board = new MeasurementBoard(connection);
            var command = MeasurementBoardCommandFactory.Command("adc start");
            var result = board.Command(command);

            Assert.Pass();
        }
    }
}