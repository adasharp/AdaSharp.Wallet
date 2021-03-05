using System.Net;
using AdaSharp.Model;
using AdaSharp.Model.Network;
using AdaSharp.Tests.TestData.Node.Network.Clock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Network
{
    [TestClass]
    public class GetClockResponseTest : TestBase
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
            var expectedOffset = new UnitOfMeasure(-4335, "microsecond");
            
            // Act
            var response = ConstructGetClockResponse(TestClockResponse.Http200);

            // Assert
            var result = response.Offset;

            AssertAreEqual(expectedOffset, result);
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