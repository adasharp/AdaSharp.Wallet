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
        public void Constructor_NodeReturnsHttp200AndNodeIsSynched_SyncProgressIsPopulated()
        {
            // Assemble
            const NetworkSyncStatus expectedSyncStatus = NetworkSyncStatus.Ready;

            // Act
            var response = ConstructGetNetworkInfoResponse(TestInformation.Http200);

            // Assert
            var result = response.SyncProgress;

            Assert.IsNotNull(result);
            Assert.IsNull(result.Progress);
            Assert.AreEqual(expectedSyncStatus, result.Status);

            // TODO: Do one when node is currently synching - verify Progress property
            // is populated.
        }

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

        private GetNetworkInfoResponse ConstructGetNetworkInfoResponse(IRestResponse responseFromNode)
        {
            return new GetNetworkInfoResponse(responseFromNode);
        }
    }
}