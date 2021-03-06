using AdaSharp.Model.Network;
using AdaSharp.Tests.TestData.Node.Network.Clock;
using AdaSharp.Tests.TestData.Node.Network.Information;
using AdaSharp.Tests.TestData.Node.Network.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests.Model.Network
{
    [TestClass]
    public class NetworkRestResourceTest : RestResourceTestBase
    {
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
            MockNodeToReturn(TestParametersResponse.Http406);

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
            MockNodeToReturn(TestInformationResponse.Http406);

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
        
        private GetClockResponse GetClockFromNode(GetClockRequest request)
        {
            var restResource = new NetworkRestResource(MockedAdaClient?.Object);

            return restResource.GetClock(request);
        }

        private GetNetworkInfoResponse GetNetworkInfoFromNode()
        {
            var restResource = new NetworkRestResource(MockedAdaClient?.Object);

            return restResource.GetNetworkInfo();
        }

        private GetNetworkParametersResponse GetNetworkParametersFromNode()
        {
            var restResource = new NetworkRestResource(MockedAdaClient?.Object);

            return restResource.GetNetworkParameters();
        }
    }
}