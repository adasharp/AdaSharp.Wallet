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
        // TODO: All these constants look ripe for some refactoring. Perhaps a separate class.
        protected const string AnyWalletId = "6b134a8fb58167ad735993bed834c779f06f340f";
        protected const string NonExistentWalletId = "0000000000000000000000000000000000000000";
        protected const string MalformedWalletId = "000";

        private const string ErrorCodeNotAcceptableContent = "not_acceptable";
        private const string ErrorMessageNotAcceptableContent =
            "It seems as though you don't accept 'application/json', but unfortunately I only " +
            "speak 'application/json'! Please double-check your 'Accept' request header and " +
            "make sure it's set to 'application/json'.";

        private const string ErrorCodeNoSuchWallet = "no_such_wallet";
        private const string ErrorMessageNoSuchWallet =
            "I couldn't find a wallet with the given id: 0000000000000000000000000000000000000000";

        private const string ErrorCodeMalformedWalletId = "bad_request";
        private const string ErrorMessageMalformedWalletId = "wallet id should be a hex-encoded string of 40 characters";

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

        protected void AssertNotAcceptableExceptionIsThrownOn(Action systemUnderTest)
        {
            const string errorCodeFromNode = "not_acceptable";
            const string errorMessageFromNode =
                "It seems as though you don't accept 'application/json', but unfortunately I only " +
                "speak 'application/json'! Please double-check your 'Accept' request header and " +
                "make sure it's set to 'application/json'.";
            const HttpStatusCode expectedHttpStatusCodeFromNode = HttpStatusCode.NotAcceptable;

            var expectedExceptionToBeThrown = new CardanoNodeException(
                errorCodeFromNode,
                errorMessageFromNode,
                expectedHttpStatusCodeFromNode);
            
            TestExpectedExceptionIsThrownOn(systemUnderTest, expectedExceptionToBeThrown);
        }

        protected void TestErrorCodeInExceptionIsNotAcceptableContent(Action systemUnderTest)
        {
            AssertErrorCodeInExceptionIs(ErrorCodeNotAcceptableContent, systemUnderTest);
        }

        protected void TestErrorCodeInExceptionIsNoSuchWallet(Action systemUnderTest)
        {
            AssertErrorCodeInExceptionIs(ErrorCodeNoSuchWallet, systemUnderTest);
        }

        protected void TestErrorCodeInExceptionIsMalformedWalletId(Action systemUnderTest)
        {
            AssertErrorCodeInExceptionIs(ErrorCodeMalformedWalletId, systemUnderTest);
        }

        protected void TestErrorMessageInExceptionIsNotAcceptableContent(Action systemUnderTest)
        {
            AssertMessageInThrownExceptionIs(ErrorMessageNotAcceptableContent, systemUnderTest);
        }

        protected void TestErrorMessageInExceptionIsNoSuchWallet(Action systemUnderTest)
        {
            AssertMessageInThrownExceptionIs(ErrorMessageNoSuchWallet, systemUnderTest);
        }

        protected void TestErrorMessageInExceptionIsMalformedWalletId(Action systemUnderTest)
        {
            AssertMessageInThrownExceptionIs(ErrorMessageMalformedWalletId, systemUnderTest);
        }

        protected void TestHttpStatusCodeInExceptionIsNotAcceptable(Action systemUnderTest)
        {
            AssertHttpStatusCodeInExceptionIs(HttpStatusCode.NotAcceptable, systemUnderTest);
        }

        protected void TestHttpStatusCodeInExceptionIsNotFound(Action systemUnderTest)
        {
            AssertHttpStatusCodeInExceptionIs(HttpStatusCode.NotFound, systemUnderTest);
        }

        protected void TestHttpStatusCodeInExceptionIsBadRequest(Action systemUnderTest)
        {
            AssertHttpStatusCodeInExceptionIs(HttpStatusCode.BadRequest, systemUnderTest);
        }

        protected void TestHttpStatusCodeInResponseIsNoContent(Func<CardanoNodeResponse> systemUnderTest)
        {
            AssertHttpStatusCodeInResponseIs(HttpStatusCode.NoContent, systemUnderTest);
        }

        protected void TestHttpStatusCodeInResponseIsOk(Func<CardanoNodeResponse> systemUnderTest)
        {
            AssertHttpStatusCodeInResponseIs(HttpStatusCode.OK, systemUnderTest);
        }

        protected void AssertHttpStatusCodeInResponseIs(HttpStatusCode expectedValue,
            Func<CardanoNodeResponse> systemUnderTest)
        {
            var responseFromNode = systemUnderTest.Invoke();

            Assert.AreEqual(expectedValue, responseFromNode.HttpStatusCode);
        }

        protected void AssertHttpStatusCodeInExceptionIs(HttpStatusCode expectedValue, Action systemUnderTest)
        {
            AssertOnExceptionCaught<CardanoNodeException>(
                actualExThrown => Assert.AreEqual(expectedValue, actualExThrown.HttpStatusCode),
                systemUnderTest);
        }

        protected void AssertErrorCodeInExceptionIs(string expectedValue, Action systemUnderTest)
        {
            AssertOnExceptionCaught<CardanoNodeException>(
                actualExThrown => Assert.AreEqual(expectedValue, actualExThrown.ErrorCode),
                systemUnderTest);
        }
    }
}