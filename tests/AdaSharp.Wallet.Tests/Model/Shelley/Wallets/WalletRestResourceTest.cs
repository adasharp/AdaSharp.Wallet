using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.TestData.Node.Wallets.Delete;
using AdaSharp.Tests.TestData.Node.Wallets.Get;
using AdaSharp.Tests.TestData.Node.Wallets.List;
using AdaSharp.Tests.TestData.Node.Wallets.Statistics.Utxos;
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
        public void GetAll_NodeReturnsHttp200_HttpStatusCodeInResponseIsOk()
        {
            // Assemble
            MockNodeToReturn(TestListResponse.Http200);

            // Act
            TestHttpStatusCodeInResponseIsOk(GetAllWalletsFromNode);
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
        public void GetWallet_NodeReturnsHttp200_ResponseReturnedIsNotNull()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http200);

            // Act
            var result = GetWalletFromNode(NominalWalletId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp200_HttpStatusCodeInResponseIsOk()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http200);

            // Act
            TestHttpStatusCodeInResponseIsOk(() => GetWalletFromNode(NominalWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp400_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http400);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => GetWalletFromNode(MalformedWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp400_HttpStatusCodeInExceptionIsBadRequest()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http400);

            // Act
            TestHttpStatusCodeInExceptionIsBadRequest(() => GetWalletFromNode(MalformedWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp400_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http400);

            // Act & Assert
            TestErrorCodeInExceptionIsMalformedWalletId(() => GetWalletFromNode(MalformedWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp400_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http400);

            // Act & Assert
            TestErrorMessageInExceptionIsMalformedWalletId(() => GetWalletFromNode(MalformedWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp404_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => GetWalletFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp404_HttpStatusCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotFound(() => GetWalletFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp404_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            // Act & Assert
            TestErrorCodeInExceptionIsNoSuchWallet(() => GetWalletFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp404_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http404);

            // Act & Assert
            TestErrorMessageInExceptionIsNoSuchWallet(() => GetWalletFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => GetWalletFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp406_HttpStatusCodeInExceptionIsNotAcceptable()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotAcceptable(() => GetWalletFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp406_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            // Act & Assert
            TestErrorCodeInExceptionIsNotAcceptableContent(() => GetWalletFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetWallet_NodeReturnsHttp406_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestGetResponse.Http406);

            // Act & Assert
            TestErrorMessageInExceptionIsNotAcceptableContent(() => GetWalletFromNode(AnyWalletId));
        }
        
        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp204_ResponseReturnedIsNotNull()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http204);

            // Act
            var result = DeleteWalletOnNode(NominalWalletId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp204_HttpStatusCodeInResponseIsNoContent()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http204);

            // Act
            TestHttpStatusCodeInResponseIsNoContent(() => DeleteWalletOnNode(NominalWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp400_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http400);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => DeleteWalletOnNode(MalformedWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp400_HttpStatusCodeInExceptionIsBadRequest()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http400);

            // Act
            TestHttpStatusCodeInExceptionIsBadRequest(() => DeleteWalletOnNode(MalformedWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp400_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http400);

            // Act & Assert
            TestErrorCodeInExceptionIsMalformedWalletId(() => DeleteWalletOnNode(MalformedWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp400_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http400);

            // Act & Assert
            TestErrorMessageInExceptionIsMalformedWalletId(() => DeleteWalletOnNode(MalformedWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp404_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => DeleteWalletOnNode(NonExistentWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp404_HttpStatusCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotFound(() => DeleteWalletOnNode(NonExistentWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp404_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            // Act & Assert
            TestErrorCodeInExceptionIsNoSuchWallet(() => DeleteWalletOnNode(NonExistentWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp404_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http404);

            // Act & Assert
            TestErrorMessageInExceptionIsNoSuchWallet(() => DeleteWalletOnNode(NonExistentWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => DeleteWalletOnNode(AnyWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp406_HttpStatusCodeInExceptionIsNotAcceptable()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotAcceptable(() => DeleteWalletOnNode(AnyWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp406_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            // Act & Assert
            TestErrorCodeInExceptionIsNotAcceptableContent(() => DeleteWalletOnNode(AnyWalletId));
        }

        [TestMethod]
        public void DeleteWallet_NodeReturnsHttp406_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestDeleteResponse.Http406);

            // Act & Assert
            TestErrorMessageInExceptionIsNotAcceptableContent(() => DeleteWalletOnNode(AnyWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp200_ResponseReturnedIsNotNull()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http200);

            // Act
            var result = GetUTxOStatisticsFromNode(NominalWalletId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp200_HttpStatusCodeInResponseIsOk()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http200);

            // Act & Assert
            TestHttpStatusCodeInResponseIsOk(() => GetUTxOStatisticsFromNode(NominalWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp404_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http404);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => GetUTxOStatisticsFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp404_HttpStatusCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http404);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotFound(() => GetUTxOStatisticsFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp404_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http404);

            // Act & Assert
            TestErrorCodeInExceptionIsNoSuchWallet(() => GetUTxOStatisticsFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp404_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http404);

            // Act & Assert
            TestErrorMessageInExceptionIsNoSuchWallet(() => GetUTxOStatisticsFromNode(NonExistentWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp406_ThrowException()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http406);

            // Act & Assert
            Assert.ThrowsException<CardanoNodeException>(() => GetUTxOStatisticsFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp406_HttpStatusCodeInExceptionIsNotAcceptable()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http406);

            // Act & Assert
            TestHttpStatusCodeInExceptionIsNotAcceptable(() => GetUTxOStatisticsFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp406_ErrorCodeInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http406);

            // Act & Assert
            TestErrorCodeInExceptionIsNotAcceptableContent(() => GetUTxOStatisticsFromNode(AnyWalletId));
        }

        [TestMethod]
        public void GetUTxOStatistics_NodeReturnsHttp406_MessageInExceptionIsPopulated()
        {
            // Assemble
            MockNodeToReturn(TestUtxosResponse.Http406);

            // Act & Assert
            TestErrorMessageInExceptionIsNotAcceptableContent(() => GetUTxOStatisticsFromNode(AnyWalletId));
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

        private GetUTxOStatisticsResponse GetUTxOStatisticsFromNode(string walletId)
        {
            var request = new GetUTxOStatisticsRequest
            {
                WalletId = walletId
            };

            var restResource = new WalletRestResource(MockedAdaClient?.Object);

            return restResource.GetUTxOStatistics(request);
        }
    }
}