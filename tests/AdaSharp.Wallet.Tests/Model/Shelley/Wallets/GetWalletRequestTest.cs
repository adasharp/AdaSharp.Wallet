using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class GetWalletRequestTest : TestBase
    {
        private const string NominalWalletId = "6b134a8fb58167ad735993bed834c779f06f340f";

        [TestMethod]
        public void ToRestRequest_WalletIdIsProvided_WalletIdIsInResourceUri()
        {
            // Assemble
            var expectedResourcePath = $"/wallets/{NominalWalletId}";

            var request = new GetWalletRequest
            {
                WalletId = NominalWalletId
            };

            // Act
            var result = request.ToRestRequest();

            // Assert
            Assert.AreEqual(expectedResourcePath, result.Resource);
        }

        [TestMethod]
        public void ToRestRequest_WalletIdIsNull_ThrowInvalidRequestException()
        {
            // Assemble
            var request = new GetWalletRequest
            {
                WalletId = null
            };

            var expectedExMsg = "A value for the \"WalletId\" property is required.";
            var expectedExceptionToBeThrown = new InvalidRequestException(expectedExMsg);

            // Act & Assert
            TestExpectedExceptionIsThrownOn(
                () => request.ToRestRequest(),
                expectedExceptionToBeThrown);
        }

        [TestMethod]
        public void ToRestRequest_AnyState_MethodInRequestIsGet()
        {
            // Assemble
            const Method expectedRestMethod = Method.GET;

            var request = CreateNominalRequest();

            // Act
            var result = request.ToRestRequest();

            // Assert
            Assert.AreEqual(expectedRestMethod, result.Method);
        }

        private GetWalletRequest CreateNominalRequest()
        {
            return new GetWalletRequest
            {
                WalletId = NominalWalletId
            };
        }
    }
}