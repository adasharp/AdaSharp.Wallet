using System;
using System.Net;
using AdaSharp.Network;
using AdaSharp.Tests.TestData.Node.Network.Information;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Network
{
    [TestClass]
    public class GetNetworkInfoResponseTest
    {
        [TestMethod]
        public void Constructor_NodeReturnsHttp200_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            // Act
            var result = ConstructGetNetworkInfoResponse(TestInformation.Http200);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsReady_ProgressIsNull()
        {
            // Act
            var response = ConstructGetNetworkInfoResponse(TestInformation.Http200SyncStatusIsReady);

            // Assert
            var result = response.SyncProgress.Progress;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsReady_StatusIsReady()
        {
            // Assemble
            const NetworkSyncStatus expectedSyncStatus = NetworkSyncStatus.Ready;

            // Act & Assert
            AssertNetworkSyncStatusIs(expectedSyncStatus, TestInformation.Http200SyncStatusIsReady);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsSyncing_StatusIsSyncing()
        {
            throw new NotImplementedException("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsSyncing_ProgressIsPopulated()
        {
            throw new NotImplementedException("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsNotResponding_StatusIsNotResponding()
        {
            throw new NotImplementedException("Need to find sample in production.");
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200AndSyncStatusIsNotResponding_ProgressIsNull()
        {
            throw new NotImplementedException("Need to find sample in production.");
        }

        // TODO: Verify eras are being deserialized correctly.

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_NodeEraIsPopulated()
        {
            // Assemble
            const Era expectedEra = Era.Mary;

            // Act
            var result = ConstructGetNetworkInfoResponse(TestInformation.Http200);

            // Assert
            Assert.AreEqual(expectedEra, result.NodeEra);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_NodeTipIsPopulated()
        {
            // Assemble
            const int expectedHeightQuantityInResponse = 2372014;
            const string expectedHeightUnitInResponse = "block";
            const string expectedTimeInResponse = "2021-03-03T05:40:16Z";
            const int expectedEpochNumInResponse = 117;
            const int expectedAbsoluteSlotNumInResponse = 20380800;
            const int expectedSlotNumInResponse = 206400;

            // Act
            var response = ConstructGetNetworkInfoResponse(TestInformation.Http200);

            // Assert
            var result = response.NodeTip;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Height);
            Assert.AreEqual(expectedHeightQuantityInResponse, result.Height.Quantity);
            Assert.AreEqual(expectedHeightUnitInResponse, result.Height.Unit);
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
            var response = ConstructGetNetworkInfoResponse(TestInformation.Http200);

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
            const string expectedNextEpochStartTimeInResponse = "2021-03-05T20:20:16Z";
            const int expectedNextEpochNumInResponse = 118;
           
            // Act
            var response = ConstructGetNetworkInfoResponse(TestInformation.Http200);

            // Assert
            var result = response.NextEpoch;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNextEpochStartTimeInResponse, result.StartTime);
            Assert.AreEqual(expectedNextEpochNumInResponse, result.Number);
        }

        private GetNetworkInfoResponse ConstructGetNetworkInfoResponse(IRestResponse responseFromNode)
        {
            return new GetNetworkInfoResponse(responseFromNode);
        }

        private void AssertNetworkSyncStatusIs(NetworkSyncStatus expectedStatus, IRestResponse responseFromNode)
        {
            // Act
            var response = ConstructGetNetworkInfoResponse(responseFromNode);

            // Assert
            var result = response.SyncProgress.Status;

            Assert.AreEqual(expectedStatus, result);
        }
    }
}