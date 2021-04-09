using CLI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Validation
{
   [TestFixture]
   public class RtdTests
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
            debugBoard.PotSetCommand(0, 10);
            debugBoard.PotSetCommand(2, 10);
        }

        [Test]
        //http://www.elettronicapratica.altervista.org/Dispense/RTD_PT100_Conversion_Chart.pdf
        [TestCaseSource("PotTestCaseSource")]
        public void CalculationTests(double ohms, double expected)
        {
            var delta = Math.Abs(.001*expected);
            var t = Common.CallendarVanDusen(ohms);

            Assert.IsTrue(Math.Abs(t - expected) < delta, $"Expected {expected} for {ohms} but got {t}. Delta {delta}");
        }
        private static IEnumerable<(double, double)> PotValueParmeters()
        {
            yield return (84.27, -40);
            yield return (88.22, -30);
            yield return (103.90, 10);
            yield return (107.79, 20);
            yield return (111.67, 30);
            yield return (115.54, 40);
            yield return (117.47, 45);
            yield return (119.40, 50);
            yield return (121.32, 55);
            yield return (123.24, 60);
            yield return (125.16, 65);
        }
        private static IEnumerable<TestCaseData> PotTestCaseSource()
        {
            foreach(var (value1, value2) in PotValueParmeters())
            {
                yield return new TestCaseData(value1, value2);
            }
        }
        [Test, TestCaseSource("PotTestCaseSource")]
        public void RtdTest(double ohms, double expected)
        {
            var delta = Math.Abs(0.001 * expected);
            debugBoard.PotSetCommand(1, (float)ohms);
            var result = measurementBoard.RtdGetCelsiusCommand();
            Assert.IsTrue(result.IsSuccess);

            // length of result
            var results = result.Result.ToArray();
            var count = results.Length;
            Assert.IsTrue(count > 1);
            var actual = float.Parse(results[count - 1 - 1]);
            Assert.IsTrue((expected - actual) < delta, $"Actual temperature {actual} exceeded expected {expected} {delta}");
        }
    }
}
