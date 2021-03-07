using System.Linq;
using AdaSharp.Model.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Network
{
    [TestClass]
    public class GetClockRequestTest : CardanoNodeRequestTestBase
    {
        [TestMethod]
        public void ToRestRequest_AnyState_ResourceInRequestIsPopulatedWithCorrectUri()
        {
            // Assemble
            const string expectedResourcePath = "/network/clock";

            var request = new GetClockRequest();

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

            var request = new GetClockRequest();

            // Act
            var result = request.ToRestRequest();

            // Assert
            Assert.AreEqual(expectedRestMethod, result.Method);
        }

        [TestMethod]
        public void ToRestRequest_ForceNtpCheckIsTrue_ForceNtpCheckParameterExistsInQuery()
        {
            // Assemble
            const string expectedParamName = "forceNtpCheck";
            var errorMsgIfAssertFails =
                $"The query parameter \"{expectedParamName}\" was not found in the request.";

            var request = new GetClockRequest
            {
                ForceNtpCheck = true
            };
            
            // Act
            var result = request.ToRestRequest();

            // Assert
            var parameterFromResult = result.Parameters.SingleOrDefault(m => m.Name == expectedParamName);
            
            Assert.IsNotNull(parameterFromResult, errorMsgIfAssertFails);
        }

        [TestMethod]
        public void ToRestRequest_ForceNtpCheckIsFalse_ForceNtpCheckParameterDoesNotExistsInQuery()
        {
            // Assemble
            const string expectedParamName = "forceNtpCheck";
            var errorMsgIfAssertFails =
                $"The query parameter \"{expectedParamName}\" was found in the request. It should not " +
                "exist in the query.";

            var request = new GetClockRequest
            {
                ForceNtpCheck = false
            };

            // Act
            var result = request.ToRestRequest();

            // Assert
            var parameterFromResult = result.Parameters.SingleOrDefault(m => m.Name == expectedParamName);

            Assert.IsNull(parameterFromResult, errorMsgIfAssertFails);
        }

        [TestMethod]
        public void ToRestRequest_AnyState_DoesNotThrowAnyExceptions()
        {
            // Assemble
            var request = new GetClockRequest();

            // Act & Assert
            TestNoExceptionIsThrownOn(() => request.ToRestRequest());
        }
    }
}