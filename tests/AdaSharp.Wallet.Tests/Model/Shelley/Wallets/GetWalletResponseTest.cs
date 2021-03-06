using System.Net;
using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.Extensions;
using AdaSharp.Tests.TestData.Node.Wallets.Get;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class GetWalletResponseTest : TestBase
    {
        [TestMethod]
        public void Constructor_NodeReturnsHttp200_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            // Act
            var result = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_WalletIsNotNull()
        {
            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_IdIsPopulated()
        {
            // Assemble
            const string expectedWalletId = "6b134a8fb58167ad735993bed834c779f06f340f";

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.Id;

            Assert.AreEqual(expectedWalletId, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_AddressPoolGapIsPopulated()
        {
            // Assemble
            const int expectedAddressPoolGap = 20;

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.AddressPoolGap;

            Assert.AreEqual(expectedAddressPoolGap, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_BalanceIsPopulated()
        {
            // Assemble
            var expectedAvailableBalance = new UnitOfMeasure(997824863, "lovelace");
            var expectedTotalBalance = new UnitOfMeasure(997824863, "lovelace");
            var expectedRewardBalance = new UnitOfMeasure(0, "lovelace");

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.Balance;

            Assert.That.AreEqual(expectedAvailableBalance, result.Available);
            Assert.That.AreEqual(expectedTotalBalance, result.Total);
            Assert.That.AreEqual(expectedRewardBalance, result.Reward);
        }

        private GetWalletResponse ConstructGetWallResponseFrom(IRestResponse responseFromNode)
        {
            return new GetWalletResponse(responseFromNode);
        }

    }
}