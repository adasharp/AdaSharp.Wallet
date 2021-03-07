﻿using AdaSharp.Model.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Network
{
    [TestClass]
    public class GetNetworkParametersRequestTest : CardanoNodeRequestTestBase
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
        public void ToRestRequest_AnyState_DoesNotThrowAnyExceptions()
        {
            // Assemble
            var request = new GetNetworkParametersRequest();

            // Act & Assert
            TestNoExceptionIsThrownOn(() => request.ToRestRequest());
        }
    }
}