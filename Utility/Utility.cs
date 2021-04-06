using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Utility
{
    public static class Utility
    {
        public static int ParseIntegerValue(string sv)
        {
            if (new Regex(@"[A-Fa-f]|0x").IsMatch(sv))
            {
                return Convert.ToInt32(sv, 16);
            }
            else
            {
                return Convert.ToInt32(sv);
            }
        }
        //int startIndex = 0;
        //int length= 5;
        //IEnumerable<int> CopyArray = Original.Skip(startIndex).Take(length);
        //static void Main(string[] args)
        //{
        //    byte[] array1 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        //    byte[] array2 = GetSlice<byte>(array1, 5, 10);
        //    for (int i = 0; i < array2.Length; i++)
        //    {
        //        Console.WriteLine(array2[i]);
        //    }
        //    Console.ReadKey();
        //}
        public static T[] GetSlice<T>(T[] array, int start, int length)
        {
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = ((start + i) < array.Length) ? array[start + i] : default(T);
            }
            return result;
        }

        public static int Bit24ToInt32(byte[] byteArray)
        {
            int result = (
                 ((0xFF & byteArray[0]) << 16) |
                 ((0xFF & byteArray[1]) << 8) |
                 (0xFF & byteArray[2])
               );
            if ((result & 0x00800000) > 0)
            {
                result = (int)((uint)result | (uint)0xFF000000);
            }
            else
            {
                result = (int)((uint)result & (uint)0x00FFFFFF);
            }
            return result;
        }

        public static int Bit16ToInt32(byte[] byteArray)
        {
            int result = (
              ((0xFF & byteArray[0]) << 8) |
               (0xFF & byteArray[1])
              );
            if ((result & 0x00008000) > 0)
            {
                result = (int)((uint)result | (uint)0xFFFF0000);

            }
            else
            {
                result = (int)((uint)result & (uint)0x0000FFFF);
            }
            return result;
        }
        public static void TestConversion()
        {
            //Test 16bit to Int32(MSB First/Left)
            Console.WriteLine("=======Test 24 bit to Int32 (MSB First/Left)=======");
            var cases = new Dictionary<int, byte[]>();
            byte[] bytearr;
            int expectedResult;

            bytearr = new byte[] { 0x7F, 0xFF, 0xFF };
            expectedResult = 8388607;//Max
            cases.Add(expectedResult, bytearr);

            bytearr = new byte[] { 0xFF, 0xFF, 0xFF };
            expectedResult = (-1);//Mid
            cases.Add(expectedResult, bytearr);

            bytearr = new byte[] { 0x80, 0x00, 0x01 };
            expectedResult = (-8388607);//Min
            cases.Add(expectedResult, bytearr);

            bytearr = new byte[] { 0x5D, 0xCB, 0xED };
            expectedResult = 6147053;//Random
            cases.Add(expectedResult, bytearr);

            bytearr = new byte[] { 0xA2, 0x34, 0x13 };
            expectedResult = (-6147053);//Random  inverted
            cases.Add(expectedResult, bytearr);

            foreach (var value in cases)
            {
                Console.WriteLine("Expected: {0} \t\t Bit24ToInt32 Test:  {1}", value.Key, Bit24ToInt32(value.Value));
            }

            Console.WriteLine("===================================================");
            Console.WriteLine();
            //Test 16bit to Int32(MSB First/Left)
            Console.WriteLine("=======Test 16 bit to Int32 (MSB First/Left)=======");
            cases.Clear();

            bytearr = new byte[] { 0x7F, 0xFF };
            expectedResult = 32767;//Max
            cases.Add(expectedResult, bytearr);

            bytearr = new byte[] { 0xFF, 0xFF };
            expectedResult = (-1);//Mid
            cases.Add(expectedResult, bytearr);

            bytearr = new byte[] { 0x80, 0x01 };
            expectedResult = (-32767);//Min
            cases.Add(expectedResult, bytearr);

            bytearr = new byte[] { 0x5D, 0xED };
            expectedResult = 24045;//Random
            cases.Add(expectedResult, bytearr);

            bytearr = new byte[] { 0xA2, 0x13 };
            expectedResult = (-24045);//Random  inverted
            cases.Add(expectedResult, bytearr);

            foreach (var value in cases)
            {
                Console.WriteLine("Expected: {0} \t\t Bit16ToInt32 Test:  {1}", value.Key, Bit16ToInt32(value.Value));
            }
            Console.WriteLine("===================================================");
            Console.ReadLine();
        }
    }
}
