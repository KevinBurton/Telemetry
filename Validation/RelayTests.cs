using CLI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    [TestFixture]
    public class RelayTests
    {
        MeasurementBoard measurementBoard;
        [SetUp]
        public void Setup()
        {
            var shared = new DebugMeasurementShared();
            var measurementBoardConnection = new TestFileConnection("MeasurementTest.txt", shared);
            measurementBoard = new MeasurementBoard(measurementBoardConnection);
        }
        [TearDown]
        public void Teardown()
        {
            if (measurementBoard != null)
            {
                measurementBoard.RelayResetCommand();
            }
        }
        [Test]
        public void CheckInvalidLatchTest()
        {
            var result = measurementBoard.LatchRelayCommand(0, 0);
            Assert.IsTrue(result.IsSuccess);
            result = measurementBoard.LatchRelayCommand(0, 1);
            Assert.IsFalse(result.IsSuccess);
        }
    }
}
