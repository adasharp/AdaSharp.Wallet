using System;
using System.Net;
using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.TestData.Node.Wallets.Delete;
using AdaSharp.Tests.TestData.Node.Wallets.Get;
using AdaSharp.Tests.TestData.Node.Wallets.List;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class WalletRestResourceTest : RestResourceTestBase
    {
        private const string NominalWalletId = "6b134a8fb58167ad735993bed834c779f06f340f";
        private const string NonExistentWalletId = "0000000000000000000000000000000000000000";

        // TODO: We verify that an exception is thrown. The message is verified but not 
        // the error code, the error message property and the HTTP status code.

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
            MockNodeToReturn(TestGetResponse.Http200);

            // Act
            var result = GetWalletFromNode(NominalWalletId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetWallet_NodeReturns404_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            var expectedExceptionToBeThrown = NoSuchWalletException();

            // Act & Assert
            TestExpectedExceptionIsThrownOn(
                () => GetWalletFromNode(NominalWalletId),
                expectedExceptionToBeThrown);
        }

        [TestMethod]
        public void GetWallet_NodeReturns400_ThrowException()
        {
            // Assemble
            const string malformedWalletId = "0000";

            MockNodeToReturn(TestGetResponse.Http400);

            var expectedExceptionToBeThrown = WalletIdIsMalformedException();

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

        [TestMethod]
        public void DeleteWallet_NodeReturns204_ResponseReturnedIsNotNull()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http204);

            // Act
            var result = DeleteWalletOnNode(NominalWalletId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns400_ThrowException()
        {
            // Assemble
            const string errorCodeFromNode = "bad_request";
            const string errorMessageFromNode = "wallet id should be a hex-encoded string of 40 characters";
            const string malformedWalletId = "0000";
            
            MockNodeToReturn(TestDeleteResponse.Http400);

            var expectedExceptionToBeThrown = new CardanoNodeException(
                errorCodeFromNode,
                errorMessageFromNode,
                HttpStatusCode.NotFound);

            // Act & Assert
            TestExpectedExceptionIsThrownOn(
                () => DeleteWalletOnNode(malformedWalletId),
                expectedExceptionToBeThrown);
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns404_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            var expectedExceptionToBeThrown = NoSuchWalletException();

            // Act & Assert
            TestExpectedExceptionIsThrownOn(
                () => DeleteWalletOnNode(NonExistentWalletId),
                expectedExceptionToBeThrown);
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            const string anyWalletId = "000";

            // Act & Assert
            AssertNotAcceptableExceptionIsThrownOn(() => DeleteWalletOnNode(anyWalletId));
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

        private DeleteWalletResponse DeleteWalletOnNode(string walletId)
        {
            var request = new DeleteWalletRequest
            {
                WalletId = walletId
            };

            var restResource = new WalletRestResource(MockedAdaClient?.Object);

            return restResource.DeleteWallet(request);
        }

        private Exception WalletIdIsMalformedException()
        {
            const string errorCodeFromNode = "bad_request";
            const string errorMessageFromNode = "wallet id should be a hex-encoded string of 40 characters";
            const HttpStatusCode expectedHttpStatusCodeFromNode = HttpStatusCode.BadRequest;

            return new CardanoNodeException(
                errorCodeFromNode,
                errorMessageFromNode,
                expectedHttpStatusCodeFromNode);
        }

        private Exception NoSuchWalletException()
        {
            const string errorCodeFromNode = "no_such_wallet";
            var errorMessageFromNode = 
                "I couldn't find a wallet with the given id: 0000000000000000000000000000000000000000";
            const HttpStatusCode expectedHttpStatusCodeFromNode = HttpStatusCode.NotFound;

            return new CardanoNodeException(
                errorCodeFromNode,
                errorMessageFromNode,
                expectedHttpStatusCodeFromNode);
        }
    }
}