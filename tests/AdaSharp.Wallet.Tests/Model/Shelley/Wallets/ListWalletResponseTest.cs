using System.Linq;
using System.Net;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.Extensions.Shelley;
using AdaSharp.Tests.TestData;
using AdaSharp.Tests.TestData.Node.Wallets.List;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class ListWalletResponseTest : CardanoNodeResponseTestBase
    {
        [TestMethod]
        public void Constructor_NodeReturnsHttp200_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            // Act
            var result = ConstructListWalletResponseFrom(TestListResponse.Http200);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsOneWallet_WalletListCountIsOne()
        {
            // Act
            var response = ConstructListWalletResponseFrom(TestListResponse.Http200);

            // Assert
            var result = response.Wallets;

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Constructor_NodeReturnsNoWallets_WalletListCountIsZero()
        {
            // Act
            var response = ConstructListWalletResponseFrom(TestListResponse.Http200NoWallets);

            // Assert
            var result = response.Wallets;

            Assert.AreEqual(0, result.Count);
        }

        /// <remarks>
        /// This test case feels a bit like duplicate code. The same properties of a Wallet instance are also
        /// verified in the "Get Wallet" test case. If something was implemented incorrectly, the
        /// other test case would fail. Naturally, it would mean there would be a problem with retrieving
        /// the list of wallets. However, I decided to add a test case here as a precaution against
        /// regression. The "Get Wallet" test case will be more in-depth, having a test-case per Wallet property.
        /// </remarks>
        [TestMethod]
        public void Constructor_NodeReturnsListOfWallets_WalletPropertiesArePopulated()
        {
            // Assemble
            var expectedWallet = TestWallet.NominalWallet;

            // Act
            var response = ConstructListWalletResponseFrom(TestListResponse.Http200);

            // Assert
            var result = response.Wallets.Single();

            Assert.That.AreEqual(expectedWallet, result);
        }

        private ListWalletResponse ConstructListWalletResponseFrom(IRestResponse responseFromNode)
        {
            return new ListWalletResponse(responseFromNode);
        }
    }
}