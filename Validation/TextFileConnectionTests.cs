using CLI;
using NUnit.Framework;
using System;
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
        [Test]
        public void MdmDisconnectTest()
        {
            var result = board.MdmDisconnectCommand();
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void MdmPacketsDroppedTest()
        {
            var result = board.MdmPacketsDroppedCommand();
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void RtcSetTimeTest()
        {
            var result = board.RtcSetTimeCommand(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Assert.IsTrue(result.IsSuccess);
        }
        [Test]
        public void AdcContTest()
        {
            var result = board.AdcContCommand();
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
        public void AllCommandsTest()
        {
            foreach(var method in methods)
            {
                var parameters = method.GetParameters();
                if(parameters.Length == 0)
                {
                    var result = method.Invoke(board, null) as MeasurementBoardCommandResult;
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
                        var result = method.Invoke(board, parameterValues) as MeasurementBoardCommandResult;
                        Assert.IsTrue(result.IsSuccess, $"Method {method.Name} is not successful");
                    }
                }
            }
        }
    }
}
