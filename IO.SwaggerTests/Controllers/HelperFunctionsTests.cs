using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}