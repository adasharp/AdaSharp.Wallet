using System;
using System.Net;
using AdaSharp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace AdaSharp.Tests.Model
{
    public abstract class RestResourceTestBase : TestBase
    {
        protected Mock<IAdaSharpClient> MockedAdaClient { get; set; }

        [TestInitialize]
        public virtual void Setup()
        {
            MockedAdaClient = new Mock<IAdaSharpClient>();
        }

        protected void MockNodeToReturn(IRestResponse responseFromNode)
        {
            MockedAdaClient
                .Setup(m => m.Send(It.IsNotNull<IRestRequest>()))
                .Returns(responseFromNode);
        }

        protected void AssertNotAcceptableExceptionIsThrownOn(Action requestResourceAction)
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