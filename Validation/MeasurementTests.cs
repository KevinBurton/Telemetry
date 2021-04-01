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
        [TearDown]
        public void Teardown()
        {
            if(measurementBoard != null)
            {
                measurementBoard.RelayResetCommand();
            }
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
        (double, double) ConfidenceInterval(double mean, double sd, int n)
        {
            // 99% confidence
            var factor = 2.576 * (sd / Math.Sqrt(n));
            return (mean + factor, mean - factor);
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
        void CheckResults(double expectedVolts, int n, ICLICommandResult result)
        {
            var measurements = new List<float>();
            foreach (var r in result.Result)
            {
                if (r[0] != '.')
                {
                    measurements.Add(float.Parse(r));
                }
            }
            var mean = Mean(measurements);
            var sd = StandardDeviation(measurements);
            double upper;
            double lower;
            (upper, lower) = ConfidenceInterval(mean, sd, n);
            Assert.IsTrue(expectedVolts < upper && expectedVolts > lower);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        [TestCase(4.0f, -4.0f, 20)]
        [TestCase(-4.0f, 4.0f, 5)]
        [TestCase(4.0f, 4.0f, 5)]
        public void CheckSr1Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 0, testVoltA);
            debugBoard.DacSetVoltCommand(1, 2, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.s1, MeasurementBoardChannels.ref1);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckSr1Ref2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 0, testVoltA);
            debugBoard.DacSetVoltCommand(1, 3, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.s1, MeasurementBoardChannels.ref2);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckSr2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 1, testVoltA);
            debugBoard.DacSetVoltCommand(1, 2, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.s2, MeasurementBoardChannels.ref1);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckSr2Ref2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 1, testVoltA);
            debugBoard.DacSetVoltCommand(1, 3, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.s2, MeasurementBoardChannels.ref2);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckPc1Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 2, testVoltA);
            debugBoard.DacSetVoltCommand(1, 2, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.pc1, MeasurementBoardChannels.ref1);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckPc1Ref2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 2, testVoltA);
            debugBoard.DacSetVoltCommand(1, 3, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.pc1, MeasurementBoardChannels.ref2);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckNcTest(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 3, testVoltA);
            debugBoard.DacSetVoltCommand(1, 2, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.nc, MeasurementBoardChannels.ref1);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckNcRef2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 3, testVoltA);
            debugBoard.DacSetVoltCommand(1, 3, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.nc, MeasurementBoardChannels.ref2);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckAccTest(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 4, testVoltA);
            debugBoard.DacSetVoltCommand(1, 2, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.acc, MeasurementBoardChannels.ref1);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckAccRef2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 4, testVoltA);
            debugBoard.DacSetVoltCommand(1, 3, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.acc, MeasurementBoardChannels.ref2);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckPc2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 5, testVoltA);
            debugBoard.DacSetVoltCommand(1, 2, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.pc2, MeasurementBoardChannels.ref1);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckPc2Ref2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 5, testVoltA);
            debugBoard.DacSetVoltCommand(1, 3, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.pc2, MeasurementBoardChannels.ref2);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckAux2Test(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(0, 6, testVoltA);
            debugBoard.DacSetVoltCommand(0, 7, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.aux2_pos, MeasurementBoardChannels.aux2_neg);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckInternalShuntTest(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(1, 0, testVoltA);
            debugBoard.DacSetVoltCommand(1, 1, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.ishnt_pos, MeasurementBoardChannels.ishnt_neg);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckPcrTest(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(1, 4, testVoltA);
            debugBoard.DacSetVoltCommand(1, 5, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.pcr_pos, MeasurementBoardChannels.pcr_neg);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
        [Test]
        [Category("Measurement")]
        [TestCase(4.0f, -4.0f, 5)]
        public void CheckExternalShuntTest(float testVoltA, float testVoltB, int n)
        {
            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(1, 6, testVoltA);
            debugBoard.DacSetVoltCommand(1, 7, testVoltB);

            var result = measurementBoard.RelayCommand(MeasurementBoardChannels.eshnt_pos, MeasurementBoardChannels.eshnt_neg);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);
        }
    }
}
