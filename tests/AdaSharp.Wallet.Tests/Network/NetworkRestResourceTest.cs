using System;
using System.Net;
using AdaSharp.Network;
using AdaSharp.Tests.TestData.Node.Network.Clock;
using AdaSharp.Tests.TestData.Node.Network.Information;
using AdaSharp.Tests.TestData.Node.Network.Parameters;
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
        public void GetNetworkParameters_NodeReturnsHttp200_ResponseReturnedIsNotNull()
        {
            // Assemble
            MockNodeToReturn(TestParametersResponse.Http200);

            // Act
            var result = GetNetworkParametersFromNode();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetNetworkParameters_NodeReturnsHttp406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestClockResponse.Http406);

            // Act & Assert
            AssertNotAcceptableExceptionIsThrownOn(() => GetNetworkParametersFromNode());
        }

        [TestMethod]
        public void GetNetworkInfo_NodeReturnsHttp200_ResponseReturnedIsNotNull()
        {
            // Assemble
            MockNodeToReturn(TestInformationResponse.Http200);

            // Act
            var result = GetNetworkInfoFromNode();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetNetworkInfo_NodeReturnsHttp406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestClockResponse.Http406);

            // Act & Assert
            AssertNotAcceptableExceptionIsThrownOn(() => GetNetworkInfoFromNode());
        }

        [TestMethod]
        public void GetClock_NodeReturnsHttp406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestClockResponse.Http406);

            var anyKindOfRequest = new GetClockRequest();

            // Act & Assert
            AssertNotAcceptableExceptionIsThrownOn(() => GetClockFromNode(anyKindOfRequest));
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

        private GetNetworkInfoResponse GetNetworkInfoFromNode()
        {
            var restResource = new NetworkRestResource(_mockedAdaClient?.Object);

            return restResource.GetNetworkInfo();
        }

        private GetNetworkParametersResponse GetNetworkParametersFromNode()
        {
            var restResource = new NetworkRestResource(_mockedAdaClient?.Object);

            return restResource.GetNetworkParameters();
        }


        private void AssertNotAcceptableExceptionIsThrownOn(Action requestResourceAction)
        {
            const string errorCodeFromNode = "not_acceptable";
            const string errorMessageFromNode =
                "It seems as though you don't accept 'application/json', but unfortunately I only " +
                "speak 'application/json'! Please double-check your 'Accept' request header and " +
                "make sure it's set to 'application/json'.";

            var expectedExceptionToBeThrown = new CardanoNodeException(
                errorCodeFromNode,
                errorMessageFromNode,
                HttpStatusCode.NotAcceptable);

            TestExpectedExceptionIsThrownOn(requestResourceAction, expectedExceptionToBeThrown);
        }
        
    }
}