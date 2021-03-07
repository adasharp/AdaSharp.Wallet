using System.Net;
using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.TestData.Node.Wallets.Get;
using AdaSharp.Tests.TestData.Node.Wallets.List;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class WalletRestResourceTest : RestResourceTestBase
    {
        [TestMethod]
        public void GetAll_NodeReturnsHttp200_ResponseReturnedIsNotNull()
        {
            // Assemble
            MockNodeToReturn(TestListResponse.Http200);

            // Act
            var result = GetAllWalletsFromNode();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll_NodeReturnsHttp406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestListResponse.Http406);

            // Act & Assert
            AssertNotAcceptableExceptionIsThrownOn(() => GetAllWalletsFromNode());
        }

        [TestMethod]
        public void GetWallet_NodeReturns200_ResponseReturnedIsNotNull()
        {
            // Assemble
            const string nominalWalletId = "6b134a8fb58167ad735993bed834c779f06f340f";

            MockNodeToReturn(TestGetResponse.Http200);

            // Act
            var result = GetWalletFromNode(nominalWalletId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetWallet_NodeReturns404_ThrowException()
        {
            // Assemble
            const string errorCodeFromNode = "no_such_wallet";
            const string errorMessageFromNode =
                "I couldn't find a wallet with the given id: 0000000000000000000000000000000000000000";
            const string badWalletId = "0000000000000000000000000000000000000000";

            MockNodeToReturn(TestGetResponse.Http404);
            
            var expectedExceptionToBeThrown = new CardanoNodeException(
                errorCodeFromNode,
                errorMessageFromNode,
                HttpStatusCode.NotFound);

            // Act & Assert
            TestExpectedExceptionIsThrownOn(
                () => GetWalletFromNode(badWalletId),
                expectedExceptionToBeThrown);
        }

        [TestMethod]
        public void GetWallet_NodeReturns400_ThrowException()
        {
            // Assemble
            const string errorCodeFromNode = "bad_request";
            const string errorMessageFromNode = "wallet id should be a hex-encoded string of 40 characters";
            const string malformedWalletId = "0000";

            MockNodeToReturn(TestGetResponse.Http400);

            var expectedExceptionToBeThrown = new CardanoNodeException(
                errorCodeFromNode,
                errorMessageFromNode,
                HttpStatusCode.NotFound);

            // Act & Assert
            TestExpectedExceptionIsThrownOn(
                () => GetWalletFromNode(malformedWalletId),
                expectedExceptionToBeThrown);
        }

        [TestMethod]
        public void GetWallet_NodeReturns406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            const string anyWalletId = "000";

            // Act & Assert
            AssertNotAcceptableExceptionIsThrownOn(() => GetWalletFromNode(anyWalletId));
        }

        private GetWalletResponse GetWalletFromNode(string walletId)
        {
            var request = new GetWalletRequest
            {
                WalletId = walletId
            };

            var restResource = new WalletRestResource(MockedAdaClient?.Object);

            return restResource.GetWallet(request);
        }

        private ListWalletResponse GetAllWalletsFromNode()
        {
            var restResource = new WalletRestResource(MockedAdaClient?.Object);

            return restResource.GetAll();
        }
    }
}