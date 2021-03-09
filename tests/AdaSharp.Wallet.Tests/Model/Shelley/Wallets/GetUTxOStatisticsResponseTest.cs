using System.Net;
using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.Extensions;
using AdaSharp.Tests.Extensions.Shelley;
using AdaSharp.Tests.TestData.Node.Wallets.Get;
using AdaSharp.Tests.TestData.Node.Wallets.Statistics.Utxos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class GetUTxOStatisticsResponseTest : CardanoNodeResponseTestBase
    {
        [TestMethod]
        public void Constructor_NodeReturnsStatistics_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            // Act
            var result = ConstructGetUTxOStatisticsResponseFrom(TestUtxosResponse.Http200);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsStatistics_StatisticsPropertyIsNotNull()
        {
            // Act
            var response = ConstructGetUTxOStatisticsResponseFrom(TestUtxosResponse.Http200);

            // Assert
            var result = response.Statistics;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsStatistics_ScaleIsPopulated()
        {
            // Assemble
            const string expectedScale = "log10";

            // Act
            var response = ConstructGetUTxOStatisticsResponseFrom(TestUtxosResponse.Http200);

            // Assert
            var result = response.Statistics.Scale;

            Assert.AreEqual(expectedScale, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsStatistics_TotalIsPopulated()
        {
            // Assemble
            var expectedTotalInResponse = QuantityInLovelace(997824863);

            // Act
            var response = ConstructGetUTxOStatisticsResponseFrom(TestUtxosResponse.Http200);

            // Assert
            var result = response.Statistics.Total;

            Assert.That.AreEqual(expectedTotalInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsStatistics_DistributionIsPopulated()
        {
            // Assemble
            var expectedDistributionInResponse = new UTxODistribution
            {
                {"10", 0},
                {"100", 0},
                {"1000", 0},
                {"10000", 0},
                {"100000", 0},
                {"1000000", 0},
                {"10000000", 0},
                {"100000000", 0},
                {"1000000000", 1},
                {"10000000000000000", 0},
                {"100000000000000", 0},
                {"1000000000000", 0},
                {"10000000000", 0},
                {"100000000000", 0},
                {"45000000000000000", 0},
                {"10000000000000", 0},
                {"1000000000000000", 0}
            };

            // Act
            var response = ConstructGetUTxOStatisticsResponseFrom(TestUtxosResponse.Http200);

            // Assert
            var result = response.Statistics.Distribution;

            Assert.That.AreEqual(expectedDistributionInResponse, result);
        }

        private GetUTxOStatisticsResponse ConstructGetUTxOStatisticsResponseFrom(IRestResponse responseFromNode)
        {
            return new GetUTxOStatisticsResponse(responseFromNode);
        }
    }
}