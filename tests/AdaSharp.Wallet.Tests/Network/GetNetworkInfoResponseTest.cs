using System.Net;
using AdaSharp.Network;
using AdaSharp.Tests.TestData.Node.Network.Information;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Network
{
    [TestClass]
    public class GetNetworkInfoResponseTest : TestBase
    {
        [TestMethod]
        public void Constructor_NodeReturnsHttp200_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            // Act
            var result = ConstructGetNetworkInfoResponse(TestInformationResponse.Http200);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsReady_ProgressIsNull()
        {
            // Act
            var response = ConstructGetNetworkInfoResponse(TestInformationResponse.Http200SyncStatusIsReady);

            // Assert
            var result = response.SyncProgress.Progress;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsReady_StatusIsReady()
        {
            // Assemble
            const SyncStatus expectedSyncStatus = SyncStatus.Ready;

            // Act & Assert
            AssertSyncStatusIs(expectedSyncStatus, TestInformationResponse.Http200SyncStatusIsReady);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsSyncing_StatusIsSyncing()
        {
            Assert.Fail("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsSyncing_ProgressIsPopulated()
        {
            Assert.Fail("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsNotResponding_StatusIsNotResponding()
        {
            Assert.Fail("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsNotResponding_ProgressIsNull()
        {
            Assert.Fail("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndEraMary_NodeEraIsMary()
        {
            // Assemble
            const Era expectedEraInResponse = Era.Mary;

            // Act & Assert
            AssertNodeEraIs(expectedEraInResponse, TestInformationResponse.Http200EraIsMary);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndEraByron_NodeEraIsAllegra()
        {
            Assert.Fail("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndEraAllegra_NodeEraIsAllegra()
        {
            Assert.Fail("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndEraShelley_NodeEraIsAllegra()
        {
            Assert.Fail("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_NodeTipIsPopulated()
        {
            // Assemble
            var expectedHeightInResponse = new UnitOfMeasure(2372014, "block");
            const string expectedTimeInResponse = "2021-03-03T05:40:16Z";
            const int expectedEpochNumInResponse = 117;
            const int expectedAbsoluteSlotNumInResponse = 20380800;
            const int expectedSlotNumInResponse = 206400;

            // Act
            var response = ConstructGetNetworkInfoResponse(TestInformationResponse.Http200);

            // Assert
            var result = response.NodeTip;

            Assert.IsNotNull(result);
            AssertAreEqual(expectedHeightInResponse, result.Height);
            Assert.AreEqual(expectedEpochNumInResponse, result.EpochNumber);
            Assert.AreEqual(expectedAbsoluteSlotNumInResponse, result.AbsoluteSlotNumber);
            Assert.AreEqual(expectedSlotNumInResponse, result.SlotNumber);
            Assert.AreEqual(expectedTimeInResponse, result.Time);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_NetworkTipIsPopulated()
        {
            // Assemble
            const string expectedTimeInResponse = "2021-03-03T05:40:28Z";
            const int expectedEpochNumInResponse = 117;
            const int expectedAbsoluteSlotNumInResponse = 20380812;
            const int expectedSlotNumInResponse = 206412;

            // Act
            var response = ConstructGetNetworkInfoResponse(TestInformationResponse.Http200);

            // Assert
            var result = response.NetworkTip;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedEpochNumInResponse, result.EpochNumber);
            Assert.AreEqual(expectedAbsoluteSlotNumInResponse, result.AbsoluteSlotNumber);
            Assert.AreEqual(expectedSlotNumInResponse, result.SlotNumber);
            Assert.AreEqual(expectedTimeInResponse, result.Time);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_NextEpochIsPopulated()
        {
            // Assemble
            var expectedNextEpoch = new Epoch(118, "2021-03-05T20:20:16Z");
            
            // Act
            var response = ConstructGetNetworkInfoResponse(TestInformationResponse.Http200);

            // Assert
            var result = response.NextEpoch;

            AssertAreEqual(expectedNextEpoch, result);
        }

        private GetNetworkInfoResponse ConstructGetNetworkInfoResponse(IRestResponse responseFromNode)
        {
            return new GetNetworkInfoResponse(responseFromNode);
        }

        private void AssertSyncStatusIs(SyncStatus expectedStatus, IRestResponse responseFromNode)
        {
            // Act
            var response = ConstructGetNetworkInfoResponse(responseFromNode);

            // Assert
            var result = response.SyncProgress.Status;

            Assert.AreEqual(expectedStatus, result);
        }

        private void AssertNodeEraIs(Era expectedEra, IRestResponse responseFromNode)
        {
            // Act
            var response = ConstructGetNetworkInfoResponse(responseFromNode);

            // Assert
            var result = response.NodeEra;

            Assert.AreEqual(expectedEra, result);
        }
    }
}