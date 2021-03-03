using System.Net;
using AdaSharp.Network;
using AdaSharp.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace AdaSharp.Tests.Network
{
    [TestClass]
    public class GetClockResponseTest
    {
        private const string Http200TestFile = @"TestData\Node\Network\Clock\Http200.json";

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            var responseFromNode = TestRestResponse.LoadHttp200From(Http200TestFile);

            // Act
            var result = ConstructGetClockResponse(responseFromNode);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_ClockStatusIsPopulated()
        {
            // Assemble
            const ClockStatus expectedClockStatus = ClockStatus.Available;

            var responseFromNode = TestRestResponse.LoadHttp200From(Http200TestFile);

            // Act
            var result = ConstructGetClockResponse(responseFromNode);

            // Assert
            Assert.AreEqual(expectedClockStatus, result.Status);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_OffsetIsPopulated()
        {
            // Assemble
            var expectedUnitInResponse = "microsecond";
            var expectedQuantityInResponse = -4335;
            var responseFromNode = TestRestResponse.LoadHttp200From(Http200TestFile);

            // Act
            var response = ConstructGetClockResponse(responseFromNode);

            // Assert
            var result = response.Offset;

            Assert.AreEqual(expectedQuantityInResponse, result.Quantity);
            Assert.AreEqual(expectedUnitInResponse, result.Unit);
        }

        private GetClockResponse ConstructGetClockResponse(Mock<IRestResponse> mockedResponse)
        {
            return new GetClockResponse(mockedResponse?.Object);
        }
    }
}