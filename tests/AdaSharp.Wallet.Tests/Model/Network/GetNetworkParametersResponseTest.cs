using System.Net;
using AdaSharp.Model.Network;
using AdaSharp.Tests.Extensions;
using AdaSharp.Tests.TestData;
using AdaSharp.Tests.TestData.Node.Network.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Network
{
    [TestClass]
    public class GetNetworkParametersResponseTest : CardanoNodeResponseTestBase
    {
        [TestMethod]
        public void Constructor_NodeReturnsHttp200_HttpStatusCodeIsOk()
        {
            // Assemble
            const HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            // Act
            var result = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            Assert.AreEqual(expectedHttpStatusCode, result.HttpStatusCode);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_GenesisBlockHashIsPopulated()
        {
            // Assemble
            const string expectedValueInResponse = "96fceff972c2c06bd3bb5243c39215333be6d56aaf4823073dca31afe5038471";

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            Assert.AreEqual(expectedValueInResponse, response.NetworkParameters.GenesisBlockHash);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_BlockchainStartTimeIsPopulated()
        {
            // Assemble
            const string expectedValueInResponse = "2019-07-24T20:20:16Z";

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            Assert.AreEqual(expectedValueInResponse, response.NetworkParameters.BlockchainStartTime);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_SlotLengthIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = QuantityInSeconds(1);
            
            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.NetworkParameters.SlotLength;

            Assert.That.AreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_EpochLengthIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = QuantityInSlots(432000);

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.NetworkParameters.EpochLength;

            Assert.That.AreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_SecurityParameterIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = QuantityInBlocks(2160);
            
            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.NetworkParameters.SecurityParameter;

            Assert.That.AreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_ActiveSlotCoefficientIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = QuantityInPercent(5);

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.NetworkParameters.ActiveSlotCoefficient;

            Assert.That.AreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_DecentralizationLevelIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = QuantityInPercent(75);

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.NetworkParameters.DecentralizationLevel;

            Assert.That.AreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_DesiredPoolNumberIsPopulated()
        {
            // Assemble
            const int expectedValueInResponse = 500;

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.NetworkParameters.DesiredPoolNumber;

            Assert.AreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_MinimumUtxoValueIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = QuantityInLovelace(1000000);

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.NetworkParameters.MinimumUtxoValue;

            Assert.That.AreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_EraEpochDictionaryIsPopulated()
        {
            // Assemble
            var expectedEraEpochDictionaryInResponse = new EraEpochDictionary
            {
                {Era.Shelley, TestEpoch.Shelley},
                {Era.Mary, TestEpoch.Mary},
                {Era.Byron, TestEpoch.Byron},
                {Era.Allegra, TestEpoch.Allegra}
            };

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.NetworkParameters.Eras;

            AssertAreEqual(expectedEraEpochDictionaryInResponse, result);
        }

        private GetNetworkParametersResponse ConstructGetNetworkParametersResponse(IRestResponse responseFromNode)
        {
            return new GetNetworkParametersResponse(responseFromNode);
        }

        private void AssertAreEqual(EraEpochDictionary expected, EraEpochDictionary actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var eraEpochPair in expected)
            {
                var expectedEra = eraEpochPair.Key;
                var expectedEpoch = eraEpochPair.Value;
                var eraExistsInActual = actual.ContainsKey(expectedEra);

                Assert.IsTrue(eraExistsInActual);

                var actualEpoch = actual[expectedEra];

                Assert.That.AreEqual(expectedEpoch, actualEpoch);
            }
        }
    }
}