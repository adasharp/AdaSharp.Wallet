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
        
        // TODO: We verify that an exception is thrown. The message is verified but not 
        // the error code, the error message property and the HTTP status code.
        // New TODO: Apply this to other test classes.

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
            Assert.ThrowsException<CardanoNodeException>(GetAllWalletsFromNode);
        }

        [TestMethod]
        public void GetAll_NodeReturnsHttp406_HttpStatusCodeInExceptionIsNotAcceptable()
        {
            // Assemble
            MockNodeToReturn(TestListResponse.Http406);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotAcceptable(() => GetAllWalletsFromNode());
        }

        [TestMethod]
        public void GetAll_NodeReturnsHttp406_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestListResponse.Http406);

            // Act & Assert
            TestErrorCodeInExceptionIsNotAcceptableContent(() => GetAllWalletsFromNode());
        }

        [TestMethod]
        public void GetAll_NodeReturnsHttp406_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestListResponse.Http406);

            // Act & Assert
            TestErrorMessageInExceptionIsNotAcceptableContent(() => GetAllWalletsFromNode());
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
        public void GetWallet_NodeReturns400_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http400);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => GetWalletFromNode(MalformedWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns400_HttpStatusCodeInExceptionIsBadRequest()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http400);

            // Act
            TestHttpStatusCodeInExceptionIsBadRequest(() => GetWalletFromNode(MalformedWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns400_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http400);

            // Act & Assert
            TestErrorCodeInExceptionIsMalformedWalletId(() => GetWalletFromNode(MalformedWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns400_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http400);

            // Act & Assert
            TestErrorMessageInExceptionIsMalformedWalletId(() => GetWalletFromNode(MalformedWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns404_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => GetWalletFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns404_HttpStatusCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotFound(() => GetWalletFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns404_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            // Act & Assert
            TestErrorCodeInExceptionIsNoSuchWallet(() => GetWalletFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns404_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            // Act & Assert
            TestErrorMessageInExceptionIsNoSuchWallet(() => GetWalletFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => GetWalletFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns406_HttpStatusCodeInExceptionIsNotAcceptable()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            // Act & Assert
            TestErrorCodeInExceptionIsNotAcceptableContent(() => GetWalletFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns406_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            // Act & Assert
            TestErrorCodeInExceptionIsNotAcceptableContent(() => GetWalletFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturns406_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            // Act & Assert
            TestErrorMessageInExceptionIsNotAcceptableContent(() => GetWalletFromNode(AnyWalletId));
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
            MockNodeToReturn(TestDeleteResponse.Http400);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => DeleteWalletOnNode(MalformedWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns400_HttpStatusCodeInExceptionIsBadRequest()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http400);

            // Act
            TestHttpStatusCodeInExceptionIsBadRequest(() => DeleteWalletOnNode(MalformedWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns400_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http400);

            // Act & Assert
            TestErrorCodeInExceptionIsMalformedWalletId(() => DeleteWalletOnNode(MalformedWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns400_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http400);

            // Act & Assert
            TestErrorMessageInExceptionIsMalformedWalletId(() => DeleteWalletOnNode(MalformedWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns404_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => DeleteWalletOnNode(NonExistentWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns404_HttpStatusCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotFound(() => DeleteWalletOnNode(NonExistentWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns404_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            // Act & Assert
            TestErrorCodeInExceptionIsNoSuchWallet(() => DeleteWalletOnNode(NonExistentWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns404_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            // Act & Assert
            TestErrorMessageInExceptionIsNoSuchWallet(() => DeleteWalletOnNode(NonExistentWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => DeleteWalletOnNode(AnyWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns406_HttpStatusCodeInExceptionIsNotAcceptable()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            // Act & Assert
            TestErrorCodeInExceptionIsNotAcceptableContent(() => DeleteWalletOnNode(AnyWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns406_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            // Act & Assert
            TestErrorCodeInExceptionIsNotAcceptableContent(() => DeleteWalletOnNode(AnyWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturns406_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            // Act & Assert
            TestErrorMessageInExceptionIsNotAcceptableContent(() => DeleteWalletOnNode(AnyWalletId));
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
    }
}