using System.Net;
using AdaSharp.Model;
using AdaSharp.Model.Network;
using AdaSharp.Tests.TestData;
using AdaSharp.Tests.TestData.Node.Network.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Network
{
    [TestClass]
    public class GetNetworkParametersResponseTest : TestBase
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
            Assert.AreEqual(expectedValueInResponse, response.GenesisBlockHash);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_BlockchainStartTimeIsPopulated()
        {
            // Assemble
            const string expectedValueInResponse = "2019-07-24T20:20:16Z";

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            Assert.AreEqual(expectedValueInResponse, response.BlockchainStartTime);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_SlotLengthIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = new UnitOfMeasure(1, "second");
            
            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.SlotLength;

            AssertAreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_EpochLengthIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = new UnitOfMeasure(432000, "slot");

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.EpochLength;

            AssertAreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_SecurityParameterIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = new UnitOfMeasure(2160, "block");
            
            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.SecurityParameter;

            AssertAreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_ActiveSlotCoefficientIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = new UnitOfMeasure(5, "percent");

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.ActiveSlotCoefficient;

            AssertAreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_DecentralizationLevelIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = new UnitOfMeasure(75, "percent");

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.DecentralizationLevel;

            AssertAreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_DesiredPoolNumberIsPopulated()
        {
            // Assemble
            const int expectedValueInResponse = 500;

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.DesiredPoolNumber;

            Assert.AreEqual(expectedValueInResponse, result);
        }

        [TestMethod]
        public void Constructor_NodeReturnsHttp200_MinimumUtxoValueIsPopulated()
        {
            // Assemble
            var expectedValueInResponse = new UnitOfMeasure(1000000, "lovelace");

            // Act
            var response = ConstructGetNetworkParametersResponse(TestParametersResponse.Http200);

            // Assert
            var result = response.MinimumUtxoValue;

            AssertAreEqual(expectedValueInResponse, result);
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
            var result = response.Eras;

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

                AssertAreEqual(expectedEpoch, actualEpoch);
            }
        }
    }
}