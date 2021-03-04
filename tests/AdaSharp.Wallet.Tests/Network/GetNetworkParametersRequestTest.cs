using AdaSharp.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Network
{
    [TestClass]
    public class GetNetworkParametersRequestTest : TestBase
    {
        [TestMethod]
        public void ToRestRequest_AnyState_ResourceInRequestIsPopulatedWithCorrectUri()
        {
            // Assemble
            const string expectedResourcePath = "/network/parameters";

            var request = new GetNetworkParametersRequest();

            // Act
            var result = request.ToRestRequest();

            // Assert
            Assert.AreEqual(expectedResourcePath, result.Resource);
        }

        [TestMethod]
        public void ToRestRequest_AnyState_MethodInRequestIsGet()
        {
            // Assemble
            const Method expectedRestMethod = Method.GET;

            var request = new GetNetworkParametersRequest();

            // Act
            var result = request.ToRestRequest();

            // Assert
            Assert.AreEqual(expectedRestMethod, result.Method);
        }

        [TestMethod]
        public void Validate_AnyState_DoesNotThrowAnyExceptions()
        {
            // Assemble
            var request = new GetNetworkParametersRequest();

            // Act & Assert
            TestNoExceptionIsThrownOn(() => request.Validate());
        }
    }
}