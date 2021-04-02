using CLI;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Validation
{
    public class TextFileConnectionTests
    {
        MeasurementBoard measurementBoard;
        MethodInfo[] measurementBoardMethods;
        DebugBoard debugBoard;
        MethodInfo[] debugBoardMethods;
        [SetUp]
        public void Setup()
        {
            var excludedMethods = new string[]
            {
                "GetType",
                "ToString",
                "Equals",
                "GetHashCode",
            };
            var shared = new DebugMeasurementShared();
            var measurementBoardConnection = new TestFileConnection("MeasurementTest.txt", shared);
            measurementBoard = new MeasurementBoard(measurementBoardConnection);
            measurementBoardMethods = typeof(MeasurementBoard).GetMethods().Where(m => !excludedMethods.Contains(m.Name)).ToArray();
            var debugBoardConnection = new TestFileConnection("DebugTest.txt", shared);
            debugBoard = new DebugBoard(debugBoardConnection);
            debugBoardMethods = typeof(DebugBoard).GetMethods().Where(m => !excludedMethods.Contains(m.Name)).ToArray();
        }
        [Test]
        public void AdcGetOfcTest()
        {
            var result = measurementBoard.AdcGetOfcCommand();
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void MdmDisconnectTest()
        {
            var result = measurementBoard.MdmDisconnectCommand();
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void MdmPacketsDroppedTest()
        {
            var result = measurementBoard.MdmPacketsDroppedCommand();
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void RtcSetTimeTest()
        {
            var result = measurementBoard.RtcSetTimeCommand(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void AdcContTest()
        {
            var result = measurementBoard.AdcContCommand();
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void AdcToggleCrcbTest()
        {
            var result = measurementBoard.AdcToggleCrcbCommand();
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void AdcReadCountsTest()
        {
            var result = measurementBoard.AdcReadCountsCommand(5);
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void AdcReadVoltsTest()
        {
            var result = measurementBoard.AdcReadVoltageCommand(5);
            Assert.IsTrue(result.IsSuccess);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [Test]
        public void AllMesurementCommandsTest()
        {
            foreach (var method in measurementBoardMethods)
            {
                var parameters = method.GetParameters();
                if (parameters.Length == 0)
                {
                    var result = method.Invoke(measurementBoard, null) as MeasurementBoardCommandResult;
                    Assert.IsTrue(result.IsSuccess, $"Method {method.Name} is not successful");
                }
                else
                {
                    object[] parameterValues = new object[parameters.Length];
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        if (parameters[i].Name.Contains("date", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        }
                        if ((parameters[i].Name.Contains("filename", StringComparison.InvariantCultureIgnoreCase) ||
                             parameters[i].Name.Contains("path", StringComparison.InvariantCultureIgnoreCase)) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].Name.Contains("directory", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8) + "/";
                        }
                        if (parameters[i].Name.Contains("flag", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = "-fl";
                        }
                        if (parameters[i].Name.Contains("expression", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].Name.Contains("userName", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].Name.Contains("destinationServer", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].ParameterType == typeof(int))
                        {
                            parameterValues[i] = 0;
                        }
                        if (parameters[i].ParameterType == typeof(float))
                        {
                            parameterValues[i] = 0f;
                        }
                    }
                    if (parameterValues.Any(p => p == null))
                    {
                        Assert.Fail($"Cannot handle {parameters.Length} parameters");
                    }
                    else
                    {
                        var result = method.Invoke(measurementBoard, parameterValues) as MeasurementBoardCommandResult;
                        Assert.IsTrue(result.IsSuccess, $"Method {method.Name} is not successful");
                    }
                }
            }
        }
        [Test]
        public void AllDebugCommandsTest()
        {
            foreach(var method in debugBoardMethods)
            {
                var parameters = method.GetParameters();
                if(parameters.Length == 0)
                {
                    var result = method.Invoke(debugBoard, null) as DebugBoardCommandResult;
                    Assert.IsTrue(result.IsSuccess, $"Method {method.Name} is not successful");
                }
                else
                {
                    object[] parameterValues = new object[parameters.Length];
                    for( var i = 0; i < parameters.Length; i++)
                    {
                        if(parameters[i].Name.Contains("date", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        }
                        if ((parameters[i].Name.Contains("filename",StringComparison.InvariantCultureIgnoreCase) ||
                             parameters[i].Name.Contains("path", StringComparison.InvariantCultureIgnoreCase)) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].Name.Contains("directory", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8) + "/";
                        }
                        if (parameters[i].Name.Contains("flag", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = "-fl";
                        }
                        if (parameters[i].Name.Contains("expression", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].Name.Contains("userName", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].Name.Contains("destinationServer", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].Name.Contains("urc", StringComparison.InvariantCultureIgnoreCase) && parameters[i].ParameterType == typeof(string))
                        {
                            parameterValues[i] = RandomString(8);
                        }
                        if (parameters[i].ParameterType == typeof(int))
                        {
                            parameterValues[i] = 0;
                        }
                        if(parameters[i].ParameterType == typeof(float))
                        {
                            parameterValues[i] = 0f;
                        }
                    }
                    if (parameterValues.Any(p => p == null))
                    {
                        Assert.Fail($"Cannot handle {parameters.Length} parameters");
                    }
                    else
                    {
                        var result = method.Invoke(debugBoard, parameterValues) as DebugBoardCommandResult;
                        Assert.IsTrue(result.IsSuccess, $"Method {method.Name} is not successful");
                    }
                }
            }
        }
    }
}
