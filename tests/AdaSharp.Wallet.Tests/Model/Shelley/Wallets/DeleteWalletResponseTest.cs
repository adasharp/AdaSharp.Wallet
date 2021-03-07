using System.Net;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.TestData.Node.Wallets.Delete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class DeleteWalletResponseTest : CardanoNodeResponseTestBase
    {
        [TestMethod]
        public void Constructor_NodeDeletedWallet_HttpStatusCodeIsNoContent()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.NoContent;

            // Act
            var result = ConstructDeleteWalletResponseFrom(TestDeleteResponse.Http204);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        private DeleteWalletResponse ConstructDeleteWalletResponseFrom(IRestResponse responseFromNode)
        {
            return new DeleteWalletResponse(responseFromNode);
        }
    }
}