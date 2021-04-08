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
        delegate ICLICommandResult MeasurementFunction(int n);
        delegate ICLICommandResult MeasurementRelayFunction(MeasurementBoardChannels first, MeasurementBoardChannels second);

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
        private static IEnumerable<TestCaseData> MeasurementTestCaseSource()
        {
            foreach(var test in MeasurementTestTypeParameters())
            {
                foreach(var testValue in MeasurementValueParmeters())
                {
                    var z = new object[test.Objects.Length + testValue.Objects.Length];
                    test.Objects.CopyTo(z, 0);
                    testValue.Objects.CopyTo(z, test.Objects.Length);
                    yield return new TestCaseData(z);
                }
            }
        }
        private static IEnumerable<TestCaseData> MeasurementIndividualTestCaseSource()
        {
            foreach (var testValue in MeasurementValueParmeters())
            {
                yield return new TestCaseData(testValue);
            }

        }
        private static IEnumerable<MeasurementValueParameter> MeasurementValueParmeters()
        {
            yield return new MeasurementValueParameter { FirstVoltage = 4.0f, SecondVoltage = -4.0f, Count = 5 };
            yield return new MeasurementValueParameter { FirstVoltage = 4.0f, SecondVoltage = -4.0f, Count = 20 };
            yield return new MeasurementValueParameter { FirstVoltage = -4.0f, SecondVoltage = 4.0f, Count = 5 };
            yield return new MeasurementValueParameter { FirstVoltage = 4.0f, SecondVoltage = 4.0f, Count = 5 };
        }
        private static IEnumerable<MeasurementTestTypeParameter> MeasurementTestTypeParameters()
        {
            yield return new MeasurementTestTypeParameter { Description = "Sr1", Dac0 = 0, Channel0 = 0, Dac1 = 1, Channel1 = 2,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.s1, MeasurementBoardChannel1 = MeasurementBoardChannels.s1 };
            yield return new MeasurementTestTypeParameter { Description = "Sr1Ref2", Dac0 = 0, Channel0 = 0, Dac1 = 1, Channel1 = 3,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.s1, MeasurementBoardChannel1 = MeasurementBoardChannels.s1 };
            yield return new MeasurementTestTypeParameter { Description = "Sr2", Dac0 = 0, Channel0 = 1, Dac1 = 1, Channel1 = 2,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.s2, MeasurementBoardChannel1 = MeasurementBoardChannels.s2 };
            yield return new MeasurementTestTypeParameter { Description = "Sr2Ref2", Dac0 = 0, Channel0 = 1, Dac1 = 1, Channel1 = 3,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.s2, MeasurementBoardChannel1 = MeasurementBoardChannels.s2 };
            yield return new MeasurementTestTypeParameter { Description = "Pc1", Dac0 = 0, Channel0 = 2, Dac1 = 1, Channel1 = 2,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.pc1, MeasurementBoardChannel1 = MeasurementBoardChannels.pc1 };
            yield return new MeasurementTestTypeParameter { Description = "Pc1Ref2", Dac0 = 0, Channel0 = 2, Dac1 = 1, Channel1 = 3,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.pc1, MeasurementBoardChannel1 = MeasurementBoardChannels.pc1 };
            yield return new MeasurementTestTypeParameter { Description = "Nc", Dac0 = 0, Channel0 = 3, Dac1 = 1, Channel1 = 2,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.nc, MeasurementBoardChannel1 = MeasurementBoardChannels.nc };
            yield return new MeasurementTestTypeParameter { Description = "NcRef2", Dac0 = 0, Channel0 = 3, Dac1 = 1, Channel1 = 3,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.nc, MeasurementBoardChannel1 = MeasurementBoardChannels.nc };
            yield return new MeasurementTestTypeParameter { Description = "Acc", Dac0 = 0, Channel0 = 4, Dac1 = 1, Channel1 = 2,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.acc, MeasurementBoardChannel1 = MeasurementBoardChannels.acc };
            yield return new MeasurementTestTypeParameter { Description = "AccRef2", Dac0 = 0, Channel0 = 4, Dac1 = 1, Channel1 = 3,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.acc, MeasurementBoardChannel1 = MeasurementBoardChannels.acc };
            yield return new MeasurementTestTypeParameter { Description = "Pc2", Dac0 = 0, Channel0 = 5, Dac1 = 1, Channel1 = 2,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.pc2, MeasurementBoardChannel1 = MeasurementBoardChannels.pc2 };
            yield return new MeasurementTestTypeParameter { Description = "Pc2Ref2", Dac0 = 0, Channel0 = 5, Dac1 = 1, Channel1 = 3,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.pc2, MeasurementBoardChannel1 = MeasurementBoardChannels.pc2 };
            yield return new MeasurementTestTypeParameter { Description = "Aux2", Dac0 = 0, Channel0 = 6, Dac1 = 0, Channel1 = 7,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.aux2_pos, MeasurementBoardChannel1 = MeasurementBoardChannels.aux2_pos };
            yield return new MeasurementTestTypeParameter { Description = "InternalShunt", Dac0 = 1, Channel0 = 0, Dac1 = 1, Channel1 = 1,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.ishnt_pos, MeasurementBoardChannel1 = MeasurementBoardChannels.ishnt_pos };
            yield return new MeasurementTestTypeParameter { Description = "Pcr", Dac0 = 1, Channel0 = 4, Dac1 = 1, Channel1 = 5,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.pcr_pos, MeasurementBoardChannel1 = MeasurementBoardChannels.pcr_pos };
            yield return new MeasurementTestTypeParameter { Description = "ExternalShunt", Dac0 = 1, Channel0 = 6, Dac1 = 1, Channel1 = 7,
                                          MeasurementBoardChannel0 = MeasurementBoardChannels.eshnt_pos, MeasurementBoardChannel1 = MeasurementBoardChannels.eshnt_pos };
        }
        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementTestCaseSource")]
        public void CheckAllTest(string description, int dac0, int channel0, int dac1, int channel1, MeasurementBoardChannels firstLatch, MeasurementBoardChannels secondLatch,
                                 float testVoltA, float testVoltB, int n)
        {
            TestContext.WriteLine($"{description} {firstLatch} {secondLatch}");

            var expectedVolts = testVoltA - testVoltB;

            debugBoard.DacSetVoltCommand(dac0, channel0, testVoltA);
            debugBoard.DacSetVoltCommand(dac1, channel1, testVoltB);

            var result = measurementBoard.RelayCommand(firstLatch, secondLatch);
            Assert.IsTrue(result.IsSuccess);

            result = measurementBoard.AdcReadVoltageCommand(n);
            Assert.IsTrue(result.IsSuccess);
            CheckResults(expectedVolts, n, result);

            result = measurementBoard.RelayResetCommand();
            Assert.IsTrue(result.IsSuccess);
        }

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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

        [Category("Measurement")]
        [Test, TestCaseSource("MeasurementIndividualTestCaseSource")]
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
