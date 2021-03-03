using System.Net;
using AdaSharp.Network;
using AdaSharp.Tests.TestData.Node.Network.Clock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace AdaSharp.Tests.Network
{
    [TestClass]
    public class NetworkRestResourceTest : TestBase
    {
        private Mock<IAdaSharpClient> _mockedAdaClient;

        [TestInitialize]
        public void Setup()
        {
            _mockedAdaClient = new Mock<IAdaSharpClient>();
        }

        [TestMethod]
        public void GetClock_NodeReturnsHttp406_ThrowException()
        {
            // Assemble
            const string errorCodeFromNode = "not_acceptable";
            const string errorMessageFromNode =
                "It seems as though you don't accept 'application/json', but unfortunately I only " +
                "speak 'application/json'! Please double-check your 'Accept' request header and " +
                "make sure it's set to 'application/json'.";

            var expectedExceptionToBeThrown = new CardanoNodeException(
                errorCodeFromNode,
                errorMessageFromNode,
                HttpStatusCode.NotAcceptable);

            MockNodeToReturn(TestClockResponse.Http406);

            var anyKindOfRequest = new GetClockRequest();

            // Act & Assert
            TestExpectedExceptionIsThrownOn(
                () => GetClockFromNode(anyKindOfRequest), 
                expectedExceptionToBeThrown);
        }

        [TestMethod]
        public void GetClock_NodeReturnsHttp200_ResponseReturnedIsNotNull()
        {
            // Assemble
            MockNodeToReturn(TestClockResponse.Http200);

            var anyKindOfRequest = new GetClockRequest();

            // Act
            var result = GetClockFromNode(anyKindOfRequest);

            // Assert
            Assert.IsNotNull(result);
        }

        private void MockNodeToReturn(IRestResponse responseFromNode)
        {
            _mockedAdaClient
                .Setup(m => m.Send(It.IsNotNull<IRestRequest>()))
                .Returns(responseFromNode);
        }

        private GetClockResponse GetClockFromNode(GetClockRequest request)
        {
            var restResource = new NetworkRestResource(_mockedAdaClient?.Object);

            return restResource.GetClock(request);
        }
        
    }
}