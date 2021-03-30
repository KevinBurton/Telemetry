using CLI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class MeasurementTests
    {
        MeasurementBoard measurementBoard;
        DebugBoard debugBoard;

        [SetUp]
        public void Setup()
        {
            var shared = new DebugMeasurementShared();
            var measurementBoardConnection = new TestFileConnection("MeasurementTest.txt", shared);
            measurementBoard = new MeasurementBoard(measurementBoardConnection);
            var debugBoardConnection = new TestFileConnection("DebugTest.txt", shared);
            debugBoard = new DebugBoard(debugBoardConnection);
        }
        double Mean(List<float> values)
        {
            var count = 0;
            var sum = 0.0;
            foreach(var value in values)
            {
                count++;
                sum += value;
            }
            return sum / count;
        }
        double StandardDeviation(List<float> values)
        {
            var count = 0;
            var mean = Mean(values);
            var sum = 0.0;
            foreach(var value in values)
            {
                count++;
                var diff = value - mean;
                sum += diff * diff;
            }
            return Math.Sqrt(sum / (count-1));
        }
        [Test]
        public void CheckVoltageTest()
        {
            var testVoltage = 2.5f;
            var result = debugBoard.DacSetVoltCommand(0, 0, testVoltage);
            Assert.IsTrue(result.IsSuccess);
            result = measurementBoard.AdcReadVoltageCommand(5);
            Assert.IsTrue(result.IsSuccess);
            var measurements = new List<float>();
            foreach(var r in result.Result)
            {
                if(r[0] != '.')
                {
                    measurements.Add(float.Parse(r));
                }
            }
            var mean = Mean(measurements);
            Assert.Less(Math.Abs(testVoltage - mean), 0.1f, "The mean voltage is not within a tolerance of 0.1");
            var sd = StandardDeviation(measurements);
            Assert.Less(sd, 0.5f, "Standard deviation is larger than 0.5");
        }
        [Test]
        public void CheckCountTest()
        {
            var testCount = 2000f;
            var result = debugBoard.DacSetCountCommand(0, 0, testCount);
            Assert.IsTrue(result.IsSuccess);
            result = measurementBoard.AdcReadCountsCommand(5);
            Assert.IsTrue(result.IsSuccess);
            var measurements = new List<float>();
            foreach (var r in result.Result)
            {
                if (r[0] != '.')
                {
                    measurements.Add(float.Parse(r));
                }
            }
            var mean = Mean(measurements);
            Assert.Less(Math.Abs(testCount - mean), 50f, "The mean voltage is not within a tolerance of 0.1");
            var sd = StandardDeviation(measurements);
            Assert.Less(sd, 225f, "Standard deviation is larger than 0.5");
        }
    }
}
