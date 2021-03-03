using System.Net;
using AdaSharp.Network;
using AdaSharp.Tests.TestData.Node.Network.Clock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Network
{
    [TestClass]
    public class GetClockResponseTest
    {
        [TestMethod]
        public void Constructor_NodeReturnsHttp200_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            // Act
            var result = ConstructGetClockResponse(TestClockResponse.Http200);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_ClockStatusIsPopulated()
        {
            // Assemble
            const ClockStatus expectedClockStatus = ClockStatus.Available;

            // Act
            var result = ConstructGetClockResponse(TestClockResponse.Http200);

            // Assert
            Assert.AreEqual(expectedClockStatus, result.Status);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_OffsetIsPopulated()
        {
            // Assemble
            var expectedUnitInResponse = "microsecond";
            var expectedQuantityInResponse = -4335;
            
            // Act
            var response = ConstructGetClockResponse(TestClockResponse.Http200);

            // Assert
            var result = response.Offset;

            Assert.AreEqual(expectedQuantityInResponse, result.Quantity);
            Assert.AreEqual(expectedUnitInResponse, result.Unit);
        }

        private GetClockResponse ConstructGetClockResponse(IRestResponse responseFromNode)
        {
            return new GetClockResponse(responseFromNode);
        }
    }
}