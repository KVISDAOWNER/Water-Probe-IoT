using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using IO.Swagger.Models;

namespace IO.Swagger.Controllers.Tests
{
    [TestClass()]
    public class DefaultApiControllerTests
    {
        DefaultApiController DAP = new DefaultApiController(new MongoDBSettings());
        
        [TestMethod()]
        public void NewData1()
        {
            // Arrange
            DeviceData DD = new DeviceData
            {
                Data = "a669ae1234",
                Device = "1D95A5",
                Time = "1573200655"
            };

            // Act
            DAP.NewData(DD);

            // Assert

        }
    }
}

namespace IO.SwaggerTests1.Controllers
{
    class DefaultApiControllerTests
    {
    }
}
