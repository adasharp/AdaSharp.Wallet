using System.Collections.Generic;
using System.Linq;
using System.Net;
using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.Extensions;
using AdaSharp.Tests.Extensions.Shelley;
using AdaSharp.Tests.TestData.Node.Wallets.Get;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class GetWalletResponseTest : CardanoNodeResponseTestBase
    {
        [TestMethod]
        public void Constructor_NodeReturnsWallet_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            // Act
            var result = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsWallet_WalletPropertyIsNotNull()
        {
            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsWallet_WalletIdIsPopulated()
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
        public void Constructor_NodeReturnsWallet_AddressPoolGapIsPopulated()
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
        public void Constructor_NodeReturnsWallet_BalanceIsPopulated()
        {
            // Assemble
            var expectedAvailableBalance = QuantityInLovelace(997824863);
            var expectedTotalBalance = QuantityInLovelace(997824863);
            var expectedRewardBalance = QuantityInLovelace(0);
            var expectedWalletBalance = BuildWalletBalance(
                expectedAvailableBalance,
                expectedRewardBalance,
                expectedTotalBalance);

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.Balance;

            Assert.That.AreEqual(expectedWalletBalance, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsWallet_DelegationIsPopulated()
        {
            // TODO: Find production examples where the wallet is not delegating and/or 
            // has a next delegation configured.
            // Assemble
            const string expectedTargetPool = "pool1e9a7zgmcpnm9tlfwv6rsalnfqgzrr644teu7m37mfh8hvwnspuf";
            var expectedActiveDelegation = DelegatingTo(expectedTargetPool);
            var expectedNextDelegation = NoPendingDelegationChanges();
            var expectedWalletDelegationSettings = BuildWalletDelegationSettings(
                expectedActiveDelegation,
                expectedNextDelegation);

            var responseFromNode = TestGetResponse.Http200WalletIsDelegatingAndHasNoNextDelegation;

            // Act
            var response = ConstructGetWallResponseFrom(responseFromNode);

            // Assert
            var result = response.Wallet.Delegation;

            Assert.That.AreEqual(expectedWalletDelegationSettings, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsWallet_AssetsIsPopulated()
        {
            // TODO: Find production examples where either Available is not zero or Total 
            // is not zero.
            // Assemble
            var expectedAvailableBalance = EmptyListOf<UnitOfMeasure>();
            var expectedTotalBalance = EmptyListOf<UnitOfMeasure>();
            var expectedAssetBalance = BuildAssetBalance(expectedAvailableBalance, expectedTotalBalance);

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.Assets;

            Assert.IsNotNull(result);
            Assert.That.AreEqual(expectedAssetBalance, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsWallet_NameIsPopulated()
        {
            // Assemble
            const string expectedName = "Test";

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.Name;

            Assert.AreEqual(expectedName, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsWallet_PassphraseIsPopulated()
        {
            // Assemble
            const string expectedLastUpdateAt = "2021-03-05T04:07:50.636736295Z";

            var expectedWalletPassphrase = BuildWalletPassphrase(expectedLastUpdateAt);

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.Passphrase;

            Assert.That.AreEqual(expectedWalletPassphrase, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsWallet_StateIsPopulated()
        {
            // TODO: Need to find more variation examples.
            // Assemble
            const SyncStatus expectedStatus = SyncStatus.Ready;
            UnitOfMeasure expectedProgress = null;

            var expectedState = BuildSyncState(expectedStatus, expectedProgress);

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.State;

            Assert.That.AreEqual(expectedState, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsWallet_TipIsPopulated()
        {
            // Assemble
            var expectedHeight = QuantityInBlocks(2380750);
            const string expectedTime = "2021-03-06T04:21:07Z";
            const int expectedEpochNumber = 118;
            const int expectedAbsoluteSlotNumber = 20635251;
            const int expectedSlotNumber = 28851;
            var expectedTip = BuildTipWithHeight(
                expectedAbsoluteSlotNumber,
                expectedSlotNumber,
                expectedEpochNumber,
                expectedTime,
                expectedHeight);

            // Act
            var response = ConstructGetWallResponseFrom(TestGetResponse.Http200);

            // Assert
            var result = response.Wallet.Tip;

            Assert.That.AreEqual(expectedTip, result);
        }

        private GetWalletResponse ConstructGetWallResponseFrom(IRestResponse responseFromNode)
        {
            return new GetWalletResponse(responseFromNode);
        }

        protected WalletDelegationSettings BuildWalletDelegationSettings(Delegation active,
            IEnumerable<DelegationChange> next)
        {
            return new WalletDelegationSettings
            {
                Active = active,
                Next = next?.ToList()
            };
        }

        protected WalletBalance BuildWalletBalance(UnitOfMeasure available, UnitOfMeasure reward, UnitOfMeasure total)
        {
            return new WalletBalance
            {
                Available = available,
                Reward = reward,
                Total = total
            };
        }

        protected Delegation DelegatingTo(string target)
        {
            return new Delegation
            {
                Status = DelegationStatus.Delegating,
                Target = target
            };
        }

        protected List<DelegationChange> NoPendingDelegationChanges()
        {
            return new List<DelegationChange>();
        }
       
    }
}