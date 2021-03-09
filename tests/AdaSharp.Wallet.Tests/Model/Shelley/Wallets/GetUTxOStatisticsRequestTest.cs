using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class GetUTxOStatisticsRequestTest : CardanoNodeRequestTestBase
    {
        private const string NominalWalletId = "6b134a8fb58167ad735993bed834c779f06f340f";

        [TestMethod]
        public void ToRestRequest_WalletIdIsProvided_WalletIdIsInResourceUri()
        {
            // Assemble
            var request = new GetUTxOStatisticsRequest
            {
                WalletId = NominalWalletId
            };

            var expectedResourcePath = $"/wallets/{NominalWalletId}/statistics/utxos";

            // Act & Assert
            AssertRestResourceUriIs(expectedResourcePath, request);
        }

        [TestMethod]
        // TODO: In the WalletRestResourceTest and other ones too, the method name does 
        // not include the exception type.
        public void ToRestRequest_WalletIdIsNull_ThrowInvalidRequestException()
        {
            // Assemble
            var request = new GetWalletRequest
            {
                WalletId = null
            };

            // Act & Assert
            Assert.ThrowsException<InvalidRequestException>(() => request.ToRestRequest());
        }

        [TestMethod]
        public void ToRestRequest_WalletIdIsNull_MessageInExceptionIsPopulated()
        {
            // Assemble
            const string expectedExMsg = "A value for the \"WalletId\" property is required.";

            var request = new GetWalletRequest
            {
                WalletId = null
            };

            // Act & Assert
            AssertMessageInThrownExceptionIs(expectedExMsg, () => request.ToRestRequest());
        }
    }
}