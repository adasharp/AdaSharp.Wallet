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
        public void Constructor_NodeReturnsHttp200AndStatusIsAvailable_ClockStatusIsAvailable()
        {
            // Assemble
            const ClockStatus expectedClockStatus = ClockStatus.Available;

            // Act & Assert
            AssertClockStatusIs(expectedClockStatus, TestClockResponse.Http200StatusIsAvailable);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndStatusIsPending_ClockStatusIsPending()
        {
            // Assemble
            const ClockStatus expectedClockStatus = ClockStatus.Pending;

            // Act & Assert
            AssertClockStatusIs(expectedClockStatus, TestClockResponse.Http200StatusIsPending);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndStatusIsUnavailable_ClockStatusIsUnavailable()
        {
            // Assemble
            const ClockStatus expectedClockStatus = ClockStatus.Unavailable;

            // Act & Assert
            AssertClockStatusIs(expectedClockStatus, TestClockResponse.Http200StatusIsUnavailable);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndStatusIsAvailable_OffsetIsPopulated()
        {
            // Assemble
            var expectedUnitInResponse = "microsecond";
            var expectedQuantityInResponse = -4335;
            
            // Act
            var response = ConstructGetClockResponse(TestClockResponse.Http200);

            // Assert
            var result = response.Offset;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedQuantityInResponse, result.Quantity);
            Assert.AreEqual(expectedUnitInResponse, result.Unit);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndStatusIsPending_OffsetIsNull()
        {
            // Act
            var response = ConstructGetClockResponse(TestClockResponse.Http200StatusIsPending);

            // Assert
            var result = response.Offset;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndStatusIsUnavailable_OffsetIsNull()
        {
            // Act
            var response = ConstructGetClockResponse(TestClockResponse.Http200StatusIsUnavailable);

            // Assert
            var result = response.Offset;

            Assert.IsNull(result);
        }

        private GetClockResponse ConstructGetClockResponse(IRestResponse responseFromNode)
        {
            return new GetClockResponse(responseFromNode);
        }

        private void AssertClockStatusIs(ClockStatus expectedStatus, IRestResponse responseFromNode)
        {
            // Act
            var response = ConstructGetClockResponse(responseFromNode);

            // Assert
            var result = response.Status;

            Assert.AreEqual(expectedStatus, result);
        }
    }
}