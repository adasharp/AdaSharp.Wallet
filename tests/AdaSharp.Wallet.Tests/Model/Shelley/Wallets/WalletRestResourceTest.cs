using AdaSharp.Model.Shelley.Wallets;
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

        private ListWalletResponse GetAllWalletsFromNode()
        {
            var restResource = new WalletRestResource(MockedAdaClient?.Object);

            return restResource.GetAll();
        }
    }
}