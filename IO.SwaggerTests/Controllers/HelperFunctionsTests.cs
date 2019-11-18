using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IO.Swagger.Models;

namespace IO.Swagger.Controllers.Tests
{
    [TestClass()]
    public class HelperFunctionsTests
    {
        [TestMethod()]
        public void UnravelpHTest1()
        {
            // Arrange
            int value = 255;
            // Act
            string result = HelperFunctions.UnravelpH(value);

            // Assert
            Assert.IsTrue("too high" == result);
        }
        [TestMethod()]
        public void UnravelpHTest2()
        {
            // Arrange
            int value = 254;

            // Act
            string result = HelperFunctions.UnravelpH(value);

            // Assert
            Assert.IsTrue("too low" == result);
        }
        [TestMethod()]
        public void UnravelpHTest3()
        {
            // Arrange
            int value = 0;
            
            // Act
            double result = double.Parse(HelperFunctions.UnravelpH(value));

            // Assert
            Assert.IsTrue(result == 5);
        }
        [TestMethod()]
        public void UnravelpHTest4()
        {
            // Arrange
            int value = 126;

            // Act
            double result = double.Parse(HelperFunctions.UnravelpH(value));

            // Assert
            Assert.IsTrue(result > 6.99 && result <= 7.01);
        }
        [TestMethod()]
        public void UnravelpHTest5()
        {
            // Arrange
            int value = 253;

            // Act
            double result = double.Parse(HelperFunctions.UnravelpH(value));

            // Assert
            Assert.IsTrue(result == 9);
        }
        [TestMethod()]
        public void UnravelTurbidity1()
        {
            // Arrange
            int value = 254;

            // Act
            string result = HelperFunctions.UnravelTurbidity(value);

            // Assert
            Assert.IsTrue("too low" == result);
        }
        [TestMethod()]
        public void UnravelTurbidity2()
        {
            // Arrange
            int value = 255;

            // Act
            string result = HelperFunctions.UnravelTurbidity(value);

            // Assert
            Assert.IsTrue("too high" == result);
        }
        [TestMethod()]
        public void UnravelTurbidity3()
        {
            // Arrange
            int value = 0;

            // Act
            double result = double.Parse(HelperFunctions.UnravelTurbidity(value));

            // Assert
            Assert.IsTrue(0 == result);
        }
        [TestMethod()]
        public void UnravelTurbidity4()
        {
            // Arrange
            int value = 253;

            // Act
            double result = double.Parse(HelperFunctions.UnravelTurbidity(value));

            // Assert
            Assert.IsTrue(3 == result);
        }
        [TestMethod()]
        public void UnravelTurbidity5()
        {
            // Arrange
            int value = 126;

            // Act
            double result = double.Parse(HelperFunctions.UnravelTurbidity(value));

            // Assert
            Assert.IsTrue(1.49 < result && result < 1.51);
        }
        [TestMethod()]
        public void UnravelTemperature1()
        {
            // Arrange
            int value = 253;

            // Act
            double result = double.Parse(HelperFunctions.UnravelTemperature(value));

            // Assert
            Assert.IsTrue(result == 30);
        }
        [TestMethod()]
        public void UnravelTemperature2()
        {
            // Arrange
            int value = 0;

            // Act
            double result = double.Parse(HelperFunctions.UnravelTemperature(value));

            // Assert
            Assert.IsTrue(result == -10);
        }
        [TestMethod()]
        public void UnravelTemperature3()
        {
            // Arrange
            int value = 254;

            // Act
            string result = HelperFunctions.UnravelTemperature(value);

            // Assert
            Assert.IsTrue(result == "too low");
        }
        [TestMethod()]
        public void UnravelTemperature4()
        {
            // Arrange
            int value = 255;

            // Act
            string result = HelperFunctions.UnravelTemperature(value);

            // Assert
            Assert.IsTrue(result == "too high");
        }
        [TestMethod()]
        public void UnravelTemperature5()
        {
            // Arrange
            int value = 126;

            // Act
            double result = double.Parse(HelperFunctions.UnravelTemperature(value));

            // Assert
            Assert.IsTrue(9.9 < result && result < 10.1);
        }
        [TestMethod()]
        public void UnravelNitrogen1()
        {
            // Arrange 
            int value = 254;

            // Act
            string result = HelperFunctions.UnravelNitrogen(value);

            // Assert
            Assert.IsTrue(result == "too low");
        }
        [TestMethod()]
        public void UnravelNitrogen2()
        {
            // Arrange 
            int value = 255;

            // Act
            string result = HelperFunctions.UnravelNitrogen(value);

            // Assert
            Assert.IsTrue(result == "too high");
        }
        [TestMethod()]
        public void UnravelNitrogen3()
        {
            // Arrange 
            int value = 0;

            // Act
            double result = double.Parse(HelperFunctions.UnravelNitrogen(value));

            // Assert
            Assert.IsTrue(result == 0);
        }
        [TestMethod()]
        public void UnravelNitrogen4()
        {
            // Arrange 
            int value = 253;

            // Act
            double result = double.Parse(HelperFunctions.UnravelNitrogen(value));

            // Assert
            Assert.IsTrue(result == 253);
        }
        [TestMethod()]
        public void UnravelNitrogen5()
        {
            // Arrange 
            int value = 126;

            // Act
            double result = double.Parse(HelperFunctions.UnravelNitrogen(value));

            // Assert
            Assert.IsTrue(result == 126);
        }
        [TestMethod()]
        public void UnravelPhosphorus1()
        {
            // Arrange 
            int value = 254;

            // Act
            string result = HelperFunctions.UnravelPhosphorus(value);

            // Assert
            Assert.IsTrue(result == "too low");
        }
        [TestMethod()]
        public void UnravelPhosphorus2()
        {
            // Arrange 
            int value = 255;

            // Act
            string result = HelperFunctions.UnravelPhosphorus(value);

            // Assert
            Assert.IsTrue(result == "too high");
        }
        [TestMethod()]
        public void UnravelPhosphorus3()
        {
            // Arrange 
            int value = 0;

            // Act
            double result = double.Parse(HelperFunctions.UnravelPhosphorus(value));

            // Assert
            Assert.IsTrue(result == 0);
        }
        [TestMethod()]
        public void UnravelPhosphorus4()
        {
            // Arrange 
            int value = 253;

            // Act
            double result = double.Parse(HelperFunctions.UnravelPhosphorus(value));

            // Assert
            Assert.IsTrue(result == 253);
        }
        [TestMethod()]
        public void UnravelPhosphorus5()
        {
            // Arrange 
            int value = 126;

            // Act
            double result = double.Parse(HelperFunctions.UnravelPhosphorus(value));

            // Assert
            Assert.IsTrue(result == 126);
        }
        [TestMethod()]
        public void Unraveltime1()
        {
            // Arrange 
            string bytes = "000000000000000000";

            // Act
            var result = HelperFunctions.UnravelTime(bytes);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == 0);
            Assert.IsTrue(result[1] == 0);
            Assert.IsTrue(result[2] == 0);
            Assert.IsTrue(result[3] == 0);
            Assert.IsTrue(result[4] == 0);
        }
        [TestMethod()]
        public void Unraveltime2()
        {
            // Arrange 
            string bytes = "000000000000000010";

            // Act
            var result = HelperFunctions.UnravelTime(bytes);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == 0);
            Assert.IsTrue(result[1] == 0);
            Assert.IsTrue(result[2] == 0);
            Assert.IsTrue(result[3] == 0);
            Assert.IsTrue(result[4] == 1);
        }
        [TestMethod()]
        public void Unraveltime3()
        {
            // Arrange 
            string bytes = "0000000000000000b0";

            // Act
            var result = HelperFunctions.UnravelTime(bytes);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == 0);
            Assert.IsTrue(result[1] == 0);
            Assert.IsTrue(result[2] == 0);
            Assert.IsTrue(result[3] == 0);
            Assert.IsTrue(result[4] == 11);
        }
        [TestMethod()]
        public void Unraveltime4()
        {
            // Arrange 
            string bytes = "0000000000000001a0";

            // Act
            var result = HelperFunctions.UnravelTime(bytes);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == 0);
            Assert.IsTrue(result[1] == 0);
            Assert.IsTrue(result[2] == 0);
            Assert.IsTrue(result[3] == 1);
            Assert.IsTrue(result[4] == 10);
        }
        [TestMethod()]
        public void Unraveltime5()
        {
            // Arrange 
            string bytes = "000000000000FFFFF0";

            // Act
            var result = HelperFunctions.UnravelTime(bytes);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == 15);
            Assert.IsTrue(result[1] == 15);
            Assert.IsTrue(result[2] == 15);
            Assert.IsTrue(result[3] == 15);
            Assert.IsTrue(result[4] == 15);
        }
        [TestMethod()]
        public void UnravelTime6()
        {
            // Arrange
            string bytes = "000000000000B63A80";

            // Act
            var result = HelperFunctions.UnravelTime(bytes);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == 11);
            Assert.IsTrue(result[1] == 6);
            Assert.IsTrue(result[2] == 3);
            Assert.IsTrue(result[3] == 10);
            Assert.IsTrue(result[4] == 8);
        }
        [TestMethod()]
        public void TimeToString1()
        {
            // Arrange
            DateTime dateTime = new DateTime(1996, 3, 27, 10, 31, 54);

            // Act
            string result = HelperFunctions.TimeToString(dateTime);

            // Assert
            Assert.IsTrue(result == "1996:03:27T10:31:54");
        }
        [TestMethod()]
        public void TimeToString2()
        {
            // Arrange
            DateTime dateTime = new DateTime(1996, 3, 9, 1, 3, 4);

            // Act
            string result = HelperFunctions.TimeToString(dateTime);

            // Assert
            Assert.IsTrue(result == "1996:03:09T01:03:04");
        }
        [TestMethod()]
        public void TimeToString3()
        {
            // Arrange
            DateTime dateTime = new DateTime(1996, 12, 9, 11, 13, 4);

            // Act
            string result = HelperFunctions.TimeToString(dateTime);

            // Assert
            Assert.IsTrue(result == "1996:12:09T11:13:04");
        }
        [TestMethod()]
        public void TimeToString4()
        {
            // Arrange
            DateTime dateTime = new DateTime(1996, 12, 20, 11, 1, 34);

            // Act
            string result = HelperFunctions.TimeToString(dateTime);

            // Assert
            Assert.IsTrue(result == "1996:12:20T11:01:34");
        }
        [TestMethod()]
        public void TimeToString5()
        {
            // Arrange
            DateTime dateTime = new DateTime(2020, 12, 20, 11, 1, 34);

            // Act
            string result = HelperFunctions.TimeToString(dateTime);

            // Assert
            Assert.IsTrue(result == "2020:12:20T11:01:34");
        }
        [TestMethod()]
        public void TimeToString6()
        {
            // Arrange
            DateTime dateTime = new DateTime(9999, 12, 31, 23, 59, 59);

            // Act
            string result = HelperFunctions.TimeToString(dateTime);

            // Assert
            Assert.IsTrue(result == "9999:12:31T23:59:59");
        }
        [TestMethod()]
        public void UnravelData1()
        {
            // Arrange
            string data = "0000000000";

            // Act
            List<string> result = HelperFunctions.UnravelData(data);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == "0");
            Assert.IsTrue(result[1] == "5");
            Assert.IsTrue(result[2] == "-10");
            Assert.IsTrue(result[3] == "0");
            Assert.IsTrue(result[4] == "0");
        }
        [TestMethod()]
        public void UnravelData2()
        {
            // Arrange
            string data = "0000000020";

            // Act
            List<string> result = HelperFunctions.UnravelData(data);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == "0");
            Assert.IsTrue(result[1] == "5");
            Assert.IsTrue(result[2] == "-10");
            Assert.IsTrue(result[3] == "0");
            Assert.IsTrue(result[4] == "32");
        }
        [TestMethod()]
        public void UnravelData3()
        {
            // Arrange
            string data = "0020000020";

            // Act
            List<string> result = HelperFunctions.UnravelData(data);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == "0");
            Assert.IsTrue(double.Parse(result[1]) >= 5.5 && double.Parse(result[1]) <= 5.51);
            Assert.IsTrue(result[2] == "-10");
            Assert.IsTrue(result[3] == "0");
            Assert.IsTrue(result[4] == "32");
        }
        [TestMethod()]
        public void UnravelData4()
        {
            // Arrange 
            string data = "FFFFFFFFFF";

            // Act
            List<string> result = HelperFunctions.UnravelData(data);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == "too high");
            Assert.IsTrue(result[1] == "too high");
            Assert.IsTrue(result[2] == "too high");
            Assert.IsTrue(result[3] == "too high");
            Assert.IsTrue(result[4] == "too high");
        }
        [TestMethod()]
        public void UnravelData5()
        {
            // Arrange 
            string data = "FEFEFEFEFE";

            // Act
            List<string> result = HelperFunctions.UnravelData(data);

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] == "too low");
            Assert.IsTrue(result[1] == "too low");
            Assert.IsTrue(result[2] == "too low");
            Assert.IsTrue(result[3] == "too low");
            Assert.IsTrue(result[4] == "too low");
        }
        [TestMethod()]
        public void UnravelData6()
        {
            // Arrange 
            string data = "a669ae1234";

            // Act
            List<double> result = HelperFunctions.UnravelData(data).Select(x => double.Parse(x)).ToList();

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] >= 1.96 && result[0] <= 1.97);
            Assert.IsTrue(result[1] >= 6.66 && result[1] <= 6.67);
            Assert.IsTrue(result[2] >= 17.5 && result[2] <= 17.51);
            Assert.IsTrue(result[3] == 18);
            Assert.IsTrue(result[4] == 52);
        }
        [TestMethod()]
        public void UnravelData7()
        {
            // Arrange 
            string data = "9a6ca574b4";

            // Act
            List<double> result = HelperFunctions.UnravelData(data).Select(x => double.Parse(x)).ToList();

            // Assert
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0] >= 1.826 && result[0] <= 1.827);
            Assert.IsTrue(result[1] >= 6.7 && result[1] <= 6.8);
            Assert.IsTrue(result[2] >= 16.08 && result[2] <= 16.09);
            Assert.IsTrue(result[3] == 116);
            Assert.IsTrue(result[4] == 180);
        }
    }
}